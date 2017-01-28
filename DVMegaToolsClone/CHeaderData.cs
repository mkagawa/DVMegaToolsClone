using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVMegaToolsClone
{
    class CHeaderData
    {
        byte[] _MyCall1 = new byte[8];
        byte[] _MyCall2 = new byte[4];
        byte[] _YourCall = new byte[8];
        byte[] _RptCall1 = new byte[8];
        byte[] _RptCall2 = new byte[8];

        public String MyCall { get { return Encoding.ASCII.GetString(_MyCall1); } }
        public String MyCall2 { get { return Encoding.ASCII.GetString(_MyCall2); } }
        public String YourCall { get { return Encoding.ASCII.GetString(_YourCall); } }
        public String RptCall1 { get { return Encoding.ASCII.GetString(_RptCall1); } }
        public String RptCall2 { get { return Encoding.ASCII.GetString(_RptCall2); } }

        public CHeaderData()
        {
            setYourCall("CQCQCQ");
        }

        private byte[] setString(String val, int maxLen)
        {
            if (val.Length > 0)
            {
                byte[] buff = new byte[maxLen];
                byte[] bval = Encoding.ASCII.GetBytes(val);
                int cnt = Encoding.ASCII.GetByteCount(val);
                Array.Copy(bval, buff, cnt);
                for (int i = cnt; i < maxLen; i++)
                {
                    buff[i] = 0x20;
                }
                return buff;
            }
            return new byte[0];
        }

        public void setMyCall(String val)
        {
            _MyCall1 = setString(val, 8);
        }
        public byte[] getMyCall()
        {
            return _MyCall1;
        }
        public void setMyCall2(String val)
        {
            _MyCall2 = setString(val, 4);
        }
        public byte[] getMyCall2()
        {
            return _MyCall2;
        }
        public void setYourCall(String val)
        {
            _YourCall = setString(val, 8);
        }
        public byte[] getYourCall()
        {
            return _YourCall;
        }
        public void setRptCall2(String val)
        {
            _RptCall2 = setString(val, 8);
        }
        public byte[] getRptCall2()
        {
            return _RptCall2;
        }
        public void setRptCall1(String val)
        {
            _RptCall1 = setString(val, 8);
        }
        public byte[] getRptCall1()
        {
            return _RptCall1;
        }

        public byte Flag1 = 0x40;
        public byte Flag2 = 0;
        public byte Flag3 = 0;
    }
}