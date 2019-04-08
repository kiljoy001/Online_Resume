using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Storage.Blob;

namespace OnlineResume.Interfaces.UploadInterface
{
    public interface IUploadToBlob
    {
        string StorageConnection { get; }
        CloudBlobContainer Container { get; }
        CloudBlobClient Client { get; }
        string FileLocation { get; set; }
        CloudBlockBlob Reference { get; }
    }
}
