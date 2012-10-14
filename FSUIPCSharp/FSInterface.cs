using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FsuipcSdk;

namespace FSUIPCSharp
{

    public class FSInterface
    {

        public Speeds Speeds { get; private set; }
        public Altitudes Altitudes { get; private set; }
        public Autopilot Autopilot { get; private set; }
        public FlightControls Controls { get; private set; }

        private Fsuipc connect;
        private bool isconnected;

        private int reqCount;

        public FSInterface()
        {
            int errorCode = 0;
            isconnected = false;
            connect = new Fsuipc();
            connect.FSUIPC_Initialization();
            if(!connect.FSUIPC_Open(0,ref errorCode))
                throw new Exception("Can't connect to FSUIPC! Error code = " + errorCode.ToString());
            else
                isconnected = true;

            reqCount = 0;
            //init all subclasses
            Speeds = new Speeds(this);
            Altitudes = new Altitudes(this);
            Autopilot = new Autopilot(this);
            Controls = new FlightControls(this);

        }

        private void reconnect()
        {
            connect.FSUIPC_Close();
            connect = new Fsuipc();
            connect.FSUIPC_Initialization();
            int errorCode = 0;
            if (!connect.FSUIPC_Open(0, ref errorCode))
                throw new Exception("Can't connect to FSUIPC! Error code = " + errorCode.ToString());
            else
                isconnected = true;
            reqCount = 0;
        }

        public long readLong(int offset,int length)
        {
            if (!isconnected)
                throw new Exception("Not connected to the Simulator!");

            if (reqCount > 1000)
                reconnect();
            else
                reqCount++;

            int result = -1;
            int token = -1;

            connect.FSUIPC_Read(offset, length, ref token, ref result);
            connect.FSUIPC_Process(ref result);
            long value = -1;

            connect.FSUIPC_Get(ref token, ref value);

            return value;
        }

        public Int32 readInt32(int offset)
        {
            if (!isconnected)
                throw new Exception("Not connected to the Simulator!");

            if (reqCount > 1000)
                reconnect();
            else
                reqCount++;

            int result = -1;
            int token = -1;

            connect.FSUIPC_Read(offset, 4, ref token, ref result);
            connect.FSUIPC_Process(ref result);
            Int32 value = -1;

            connect.FSUIPC_Get(ref token, ref value);

            return value;
        }

        public double readFloat(int offset)
        {
            if (!isconnected)
                throw new Exception("Not connected to the Simulator!");

            if (reqCount > 1000)
                reconnect();
            else
                reqCount++;

            int result = -1;
            int token = -1;

            connect.FSUIPC_Read(offset, 8, ref token, ref result);
            connect.FSUIPC_Process(ref result);
            double value = -1;
            byte[] rawValue = new byte[8];
            connect.FSUIPC_Get(ref token,8, ref rawValue);

            value = BitConverter.ToDouble(rawValue, 0);

            return value;
        }

        public Int16 readInt16(int offset)
        {
            if (!isconnected)
                throw new Exception("Not connected to the Simulator!");

            if (reqCount > 1000)
                reconnect();
            else
                reqCount++;

            int result = -1;
            int token = -1;

            connect.FSUIPC_Read(offset, 2, ref token, ref result);
            connect.FSUIPC_Process(ref result);
            Int16 value = -1;

            connect.FSUIPC_Get(ref token, ref value);

            return value;
        }

        public void writeInt(int offset, int value)
        {
            int token = 0;
            int result = 0;
            connect.FSUIPC_Write(offset, value, ref token, ref result);
            connect.FSUIPC_Process(ref result);
        }

    }
}
