using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Interfaces.Utility
{
    interface IBlobSettings
    {
        string ConnectionStringName { get; set; }
        string BlobKeyName { get; set; }
        string ContainerName { get; set; }
        string BlockBlob { get; set; }
    }
}
