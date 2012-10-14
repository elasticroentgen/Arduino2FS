using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSUIPCSharp
{
    public class Autopilot
    {
        public int Heading
        {
            get
            {
                double fsread = fs.readInt32(0x07CC);
                fsread = fsread / 65536 * 360;
                return int.Parse(fsread.ToString("0"));
            }
            set
            {
                fs.writeInt(0x07CC, ((value * 65536) / 360));
            }
        }
        public int Altitude
        {
            get
            {
                return Convert.ToInt32(fs.readInt32(0x07D4) / 65536 * 3.2808399);
            }
            set
            {
                int valinmeters = (int)((value * 65536) / 3.2808399);
                fs.writeInt(0x07D4, valinmeters);
            }
        }
        public int Speed { get { return fs.readInt16(0x07E2); } }

        private FSInterface fs;
        public Autopilot(FSInterface fsi)
        {
            fs = fsi;
        }
    }
}
