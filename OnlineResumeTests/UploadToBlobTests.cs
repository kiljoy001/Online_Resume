using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineResume.Utility;
using OnlineResumeTests.Utility;

namespace OnlineResumeTests
{
    [TestClass]
    public class UploadToBlobTests
    {
        private List<string> FileList = new List<string>();
        private string TempPath;
        private string TestFileHash;


        [TestMethod]
        public void Can_Upload_File_To_Blob_Storage()
        {
            //Arrange
            //Start the emulator
            StartStorageEmulator emulator = new StartStorageEmulator();
            emulator.Start();
            var mockIConfig = new Mock<IConfiguration>();
            var mockIOption = new Mock<IOptions<BlobSettings>>();
            var mockBlobSettings = new Mock<BlobSettings>();

            BlobSettings MockBlobSettings = mockBlobSettings.Object;
            IConfiguration MockedConfig = mockIConfig.Object;
            IOptions<BlobSettings> MockedBlobConfig = mockIOption.Object;
            //Set Mocked properties & output
            mockIConfig.Setup(m => m.GetConnectionString(It.IsAny<string>())).Returns("DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;");

            mockBlobSettings.Setup(x =>
                x.ConnectionStringName == "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;" &&
                x.BlobKeyName == "BlobKey1" &&
                x.ContainerName == "test" &&
                x.BlockBlob =="BlockBlob"
                );
            mockIOption.Setup(x => x.Value == MockBlobSettings);
            //set path & name for the test file
            TempPath = Path.GetTempFileName();
            //get file hash
            TestFileHash = CreateFileWithRandomDataAndReturnHash(TempPath);
            UploadToBlob uploader = new UploadToBlob(MockedConfig, MockedBlobConfig)
            {
                FileLocation = TempPath
            };

            //Act
            uploader.Upload();

            //Assert
            CloudStorageAccount EmulatedStorage = CloudStorageAccount.Parse(MockedConfig.GetConnectionString("connectionstring"));
            CloudBlobClient BlobClient = EmulatedStorage.CreateCloudBlobClient();
            CloudBlobContainer Container = BlobClient.GetContainerReference("test");
            var Blobs = Container.ListBlobs(useFlatBlobListing: true);
            List<string> BlobItems = new List<string>();
            foreach(var blob in Blobs)
            {
                var blobFileName = blob.Uri.Segments[blob.Uri.Segments.Length -1];
                BlobItems.Add(blobFileName);
            }
            Assert.IsTrue(BlobItems.Contains(GetTempFileName(uploader.FileLocation)));
        }

        private string CreateFileWithRandomDataAndReturnHash(string location)
        {
            //byte arrays
            byte[] hash;
            byte[] data = new byte[45000];
            //create random byte number and write to to file
            Random rng = new Random();
            rng.NextBytes(data);
            File.WriteAllBytes(location, data);
            //Add file to file list for removal during clean up phase
            FileList.Add(location);
            //Get MD5 hash of file in byte array format
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(location))
                {
                    hash = md5.ComputeHash(stream);
                }
            }
            //Encode the byte array hash into UTF8 and return the value as a string
            return Encoding.UTF8.GetString(hash);
        }

        private void CleanUpFiles(List<string> Locations)
        {
            foreach(string location in Locations)
            {
                File.Delete(location);
            }
        }

        private string GetTempFileName(string location)
        {
            string[] splitPath = location.Split(@"\");
            return splitPath[splitPath.Length - 1];
        }

    }
}
