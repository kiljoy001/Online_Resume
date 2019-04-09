using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OnlineResume.Interfaces.Utility;
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
        private readonly string ConnectionStringName;
        private readonly string BlobKeyName;
        private readonly string ContainerName;
        private readonly string BlockBlob;

        public UploadToBlob(IConfiguration configuration, IOptions<BlobSettings> blobsetting)
        {
            _configuration = configuration;
            BlobOptions = blobsetting.Value;
            ConnectionStringName = BlobOptions.ConnectionStringName;
            BlobKeyName = BlobOptions.BlobKeyName;
            ContainerName = BlobOptions.ContainerName;
            BlockBlob = BlobOptions.BlockBlob;
        }

        public string FileLocation { get; set; }
        private BlobSettings BlobOptions {get; set;}

        public void CleanUp()
        {
            throw new NotImplementedException();
        }

        public async void Upload()
        {
            //parse connection string & create blob client
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration[ConnectionStringName]);
            CloudBlobClient bClient = storageAccount.CreateCloudBlobClient();
            //Get Blob container reference
            CloudBlobContainer blobContainer = bClient.GetContainerReference(ContainerName);
            //Create blob block for uploading
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(BlockBlob);
            //Upload the file
            await blob.UploadFromFileAsync(FileLocation);
        }
    }
}
