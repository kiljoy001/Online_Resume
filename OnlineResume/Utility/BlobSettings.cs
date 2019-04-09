using OnlineResume.Interfaces.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Utility
{
    public class BlobSettings : IBlobSettings
    {
        public string ConnectionStringName { get; set; }
        public string BlobKeyName { get; set; }
        public string ContainerName { get; set; }
        public string BlockBlob { get; set; }
    }
}
