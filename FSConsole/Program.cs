using FSUIPCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FSInterface fs = new FSInterface();

            int hdg = 1000;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Altitude: " + fs.Altitudes.Altimeter + "ft (" + fs.Altitudes.AltimeterPressure +")");
                Console.WriteLine("IAS/TAS/GS :" + fs.Speeds.ToString());

                Console.WriteLine(" == AUTOPILOT ==");
                Console.WriteLine("ALT : " + fs.Autopilot.Altitude);
                Console.WriteLine("SPD : " + fs.Autopilot.Speed);
                Console.WriteLine("HDG : " + fs.Autopilot.Heading);

                Thread.Sleep(200);

                //hdg++;
                //fs.Autopilot.Altitude = hdg;
            }
        }
    }
}
