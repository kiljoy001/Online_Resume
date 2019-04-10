using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Interfaces.Utility
{
    interface IStorageEmulatorSettings
    {
        string AccountName { get; set; }
        string AccountKey { get; set; }
        string BlobEndPoint { get; set; }
    }
}
