using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace OnlineResume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadResumeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UploadResumeController(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var size = file.Length;

            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            // upload document to Azure Blob Storage

            return Ok(new { count = file.FileName, size, filePath });
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var secretName = "storagename";
        //    var secretValue = _configuration[secretName];

        //    if (secretValue == null)
        //    {
        //        return StatusCode(
        //            StatusCodes.Status500InternalServerError,
        //            $"Error: No secret named {secretName} was found...");
        //    }
        //    else
        //    {
        //        return Content($"Secret value: {secretValue}" +
        //            Environment.NewLine + Environment.NewLine +
        //            "This is for testing only! Never output a secret " +
        //            "to a response or anywhere else in a real app!");
        //    }
        //}
    }
}