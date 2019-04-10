using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using OnlineResumeTests.TestInterfaces;

namespace OnlineResumeTests.Utility
{
    public class StartStorageEmulator : IStartStorageEmulator
    {
        private string Location = Environment.ExpandEnvironmentVariables(@"%PROGRAMFILES(X86)%\Microsoft SDKs\Azure\Storage Emulator\AzureStorageEmulator.exe");
        int ExitCode { get; set; }

        public void Start()
        {
            //Check if process is already running
            var process = GetProccessList();
            if(StorageEmulatorProcExists(process))
            {
                return;
            }

            ProcessStartInfo StartInfo = new ProcessStartInfo(Location)
            {
                Arguments = "start",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            

            using (var startEmulatorProc = Process.Start(StartInfo))
            {
                startEmulatorProc.WaitForExit();
                ExitCode = startEmulatorProc.ExitCode;
            }
        }

        public void CleanUp()
        {
            var process = GetProccessList();
            if(StorageEmulatorProcExists(process))
            {
                var KillMe = process.FirstOrDefault(x => x.ProcessName.Contains("AzureStorageEmulator"));
                KillMe.Kill();
            }
        }
        
        private List<Process> GetProccessList()
        {
            return Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();
        }
        
        private bool StorageEmulatorProcExists(List<Process> process)
        {
            return process.Any(p => p.ProcessName.Contains("AzureStorageEmulator"));
        }
    }
}
