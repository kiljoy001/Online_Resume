﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Storage.Blob;

namespace OnlineResume.Interfaces.UploadInterface
{
    public interface IUploadToBlob
    {
        void Upload();
    }
}
