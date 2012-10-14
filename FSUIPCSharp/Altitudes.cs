using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSUIPCSharp
{
    public class Altitudes
    {

        public double Altimeter { get { return (fs.readLong(0x3324, 4)); } }
        public double AltimeterPressure { get { return fs.readLong(0x0330, 4) / 16; } }

        private FSInterface fs;
        public Altitudes(FSInterface fsi)
        {
            fs = fsi;
        }
    }
}
