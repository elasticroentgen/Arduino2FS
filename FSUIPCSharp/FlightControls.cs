using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSUIPCSharp
{
    public class FlightControls
    {
        /// <summary>
        /// Get the current Rudder trim (-1 to 1)
        /// </summary>
        public double RudderTrim { get { return Math.Round(fs.readFloat(0x2EC0) * (180 /Math.PI),3); } }
        public double ElevatorTrim { get { return Math.Round(fs.readFloat(0x2EA0) * (180 / Math.PI), 3); } }
        public double AileronTrim { get { return Math.Round(fs.readFloat(0x2EB0) * (180 / Math.PI), 3); } }

        private FSInterface fs;
        public FlightControls(FSInterface fsi)
        {
            fs = fsi;
        }
    }
}
