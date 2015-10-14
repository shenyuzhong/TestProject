using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    // ManagedFloat stores data in both float and byte form so that it can be 
    // readily passes to an unmanaged C DLL
    public class ManagedFloat
    {
        public ManagedFloat(float input)
        {
            FloatData = input;
        }
        private float floatData;
        public float FloatData
        {
            get { return floatData; }
            set
            {
                floatData = value;
                byteData = Encoding.ASCII.GetBytes(value.ToString().ToCharArray());
            }
        }

        private byte[] byteData;
        public byte[] ByteData
        {
            get { return byteData; }
        }
    }
}
