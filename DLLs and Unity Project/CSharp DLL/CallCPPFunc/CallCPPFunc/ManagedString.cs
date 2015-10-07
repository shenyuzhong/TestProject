using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    // ManagedString stores data in both string and byte form so that it can be 
    // readily passed to an unmanaged C DLL
    public class ManagedString
    {
        public ManagedString(string input)
        {
            StrData = input;
        }
        private string strData;
        public string StrData
        {
            get { return strData; }
            set
            {
                strData = value;
                byteData = Encoding.ASCII.GetBytes(value.ToCharArray());
            }
        }

        private byte[] byteData;
        public byte[] ByteData
        {
            get { return byteData; }
        }
    }
}
