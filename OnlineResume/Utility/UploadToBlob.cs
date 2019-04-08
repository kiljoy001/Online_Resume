using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using OnlineResume.Interfaces.UploadInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace OnlineResume.Utility
{
    public class UploadToBlob : IUploadToBlob
    {
        private readonly IConfiguration _configuration;
        private string ConnectionStringName;
        private string BlobKeyName;
        public UploadToBlob(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionStringName = "BlobKey1ConnectionString";
            BlobKeyName = "BlobKey1";
        }



        public string FileLocation { get; set; }

        public void Upload()
        {
            
        }
    }
}
