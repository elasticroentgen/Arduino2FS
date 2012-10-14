using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSUIPCSharp
{
    public class Speeds
    {
        public long IndicatedAirspeed { get { return fs.readLong(0x02BC, 4) / 128; } }
        public long TrueAirspeed { get { return fs.readLong(0x02B8, 4) / 128; } }
        public double GroundSpeed { get { return (fs.readLong(0x02B4, 4) / 65536) * 3.6; } }

        private FSInterface fs;

        public Speeds(FSInterface fsi)
        {
            fs = fsi;
        }

        public override string ToString()
        {
            return IndicatedAirspeed.ToString() + "/" + TrueAirspeed.ToString() + "/" + GroundSpeed.ToString();
        }

    }
}
