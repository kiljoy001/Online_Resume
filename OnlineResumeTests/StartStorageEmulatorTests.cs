using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineResumeTests.Utility;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace OnlineResumeTests
{
    [TestClass]
    public class StartStorageEmulatorTests
    {
        [TestMethod]
        public void Azure_Emulator_Starts()
        {
            //Arrange
            StartStorageEmulator StartUp = new StartStorageEmulator();
            //Act
            StartUp.Start();
            //Assert
            var processes = Process.GetProcesses().OrderBy(x => x.ProcessName).ToList();
            Assert.IsTrue(processes.Any(x => x.ProcessName.Contains("AzureStorageEmulator")));
        }

        [TestMethod]
        public void Can_Kill_Emulator()
        {
            //Arrange
            StartStorageEmulator StartUp = new StartStorageEmulator();

            //Act
            StartUp.Start();
            System.Threading.Thread.Sleep(1000);
            StartUp.CleanUp();
            System.Threading.Thread.Sleep(000);
            //Assert
            var processes = Process.GetProcesses().OrderBy(x => x.ProcessName).ToList();
            Assert.IsFalse(processes.Any(x => x.ProcessName.Contains("AzureStorageEmulator")));

        }

        
    }
}
