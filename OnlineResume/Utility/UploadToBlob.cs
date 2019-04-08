using Microsoft.Azure.Storage.Blob;
using OnlineResume.Interfaces.UploadInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Utility
{
    public class UploadToBlob : IUploadToBlob
    {
        public UploadToBlob()
        {
            
        }

        public string StorageConnection => throw new NotImplementedException();

        public CloudBlobContainer Container => throw new NotImplementedException();

        public CloudBlobClient Client => throw new NotImplementedException();

        public string FileLocation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CloudBlockBlob Reference => throw new NotImplementedException();
    }
}
