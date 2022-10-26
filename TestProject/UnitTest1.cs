using NUnit.Framework;
using System.Diagnostics;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:\\Program Files\\Notepad++\\notepad++.exe",
                    Arguments = "behavior query SymlinkEvaluation",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                   
                    
                }
            };

            process.Start();

           
        }

        [Test]
        public void Test1()
        {
            var result = true;
            new KillProcessApp.KillProcessService().KillProcess("notepad++");
            var processCount = System.Diagnostics.Process.GetProcessesByName("notepad++").Length;
            if (processCount > 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            Assert.IsTrue(result,"All process are been deleted");
        }
    }
}