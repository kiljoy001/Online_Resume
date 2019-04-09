﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineResume.Interfaces;
using OnlineResume.Interfaces.ResumeParts;
using OnlineResume.Interfaces.Utility;
using OnlineResume.Models;
using OnlineResume.Utility;

namespace OnlineResume
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //IOC Services
            services.AddScoped<IResume, Resume>();
            services.AddScoped<IResumeSkill, ResumeSkill>();
            services.AddScoped<IResumeTextBlock, ResumeTextBlock>();
            services.AddSingleton<IUploadToBlob, UploadToBlob>();
            services.AddSingleton<IBlobSettings, BlobSettings>();

            //Read AppSettings
            services.Configure<BlobSettings>(Configuration.GetSection("BlobSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
