using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KillProcessApp
{
    public class KillProcessService
    {



        public string processName = "";
        public int maxLifetime = 0;
        public int monitorFrequency = 0;
        public System.Threading.Thread WorkThread;


        public bool GoOn;
        public DateTime dateStartApp;
        public KillProcessService(string processName, int maxLifeTime, int monitorFrequency)
        {
            this.processName = processName;
            this.maxLifetime = maxLifeTime;
            this.monitorFrequency = monitorFrequency;
            dateStartApp = DateTime.Now;
            GoOn = true;
            WorkThread = new System.Threading.Thread(Work);
            WorkThread.Start();

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Q was pressed :  utility stopped");
                    WorkThread.Interrupt();
                    Environment.Exit(-1);
                    
                }

            }
            while (true);

        }

        public KillProcessService() { }





        public void Work()
        {

            while (GoOn)
            {
                KillProcess(processName);

                System.Threading.Thread.Sleep(Convert.ToInt32(TimeSpan.FromMinutes(monitorFrequency).TotalMilliseconds));
            }



        }

        public void KillProcess(string processName)
        {
            System.Diagnostics.Process[] processByName = System.Diagnostics.Process.GetProcessesByName(processName);

            if (processByName.Length > 0)
            {
                foreach (var process in processByName)
                {
                    if (DateTime.Now > dateStartApp.AddMinutes(maxLifetime))
                    {
                        process.Kill();
                        Console.WriteLine($"Process with id {process.Id} was killed ");
                    }
                    else
                        Console.WriteLine($"There are process with process name : {process} to killed but the alive time is not passed");
                }

            }
            else
                Console.WriteLine($"The aren't proces with name {processName}");


        }
    }
}