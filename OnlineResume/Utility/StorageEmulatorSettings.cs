using OnlineResume.Interfaces.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Utility
{
    public class StorageEmulatorSettings : IStorageEmulatorSettings
    {
        public string AccountName { get; set;}
        public string AccountKey { get; set; }
        public string BlobEndPoint { get; set;}
    }
}
