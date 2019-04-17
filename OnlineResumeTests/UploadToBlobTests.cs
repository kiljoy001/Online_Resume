using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineResume.Utility;

namespace OnlineResumeTests
{
    [TestClass]
    public class UploadToBlobTests
    {
        [TestMethod]
        public void Can_Upload_File_To_Blob_Storage()
        {
            //Arrange
            var mockIConfig = new Mock<IConfiguration>();
            var mockIOption = new Mock<IOptions<BlobSettings>>();
            var mockBlobSettings = new Mock<BlobSettings>();

            BlobSettings MockBlobSettings = mockBlobSettings.Object;
            IConfiguration MockedConfig = mockIConfig.Object;
            IOptions<BlobSettings> MockedBlobConfig = mockIOption.Object;
            //Set Mocked properties
            mockIConfig.Setup(m => m.GetConnectionString(It.IsAny<string>())).Returns("DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;");

            mockBlobSettings.Setup(x =>
                x.ConnectionStringName == "" &&
                x.BlobKeyName == "" &&
                x.ContainerName == "" &&
                x.BlockBlob ==""
                );
            mockIOption.Setup(x => x.Value == MockBlobSettings);

        }
    }
}
