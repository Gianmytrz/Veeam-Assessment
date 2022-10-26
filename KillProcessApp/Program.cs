using System;
using System.Threading;

namespace KillProcessApp
{
    internal class Program
    {
        static Timer myTimer;

        static void Main(string[] args)
        {

            int maxLifeTime = 0;
            int monitorFrequency = 0;
           // var killProcess = new KillProcessService("notepad++", 2, 1);

            var nameProcess = args[0];
            var tryMaxLife = Int32.TryParse(args[1], out maxLifeTime);
            var tryMonitorFreq = Int32.TryParse(args[2], out monitorFrequency);

            if (tryMaxLife && tryMonitorFreq)
            {
                Console.WriteLine(nameProcess + "   " + maxLifeTime + "  " + monitorFrequency);
                new KillProcessService(nameProcess, maxLifeTime, monitorFrequency);
            }



        }

        
    }
}
