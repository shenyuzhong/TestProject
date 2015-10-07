using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMath
{
    public abstract class Expression
    {
        public Expression()
        {
            // Set default variable to x
            Var = new ManagedString("x");

            // Set A, B, C, D so default equation is 1*(1*x+0)^2+0
            AVertStretch = new ManagedFloat(1f);
            BHorizStretch = new ManagedFloat(1f);
            CHorizShift = new ManagedFloat(0f);
            DVertShift = new ManagedFloat(0f);

            // Generate intial expression x**2
            ExprString = new ManagedString("");
            PlotString = new ManagedString("");
            PyExpression();

            // Set default equation color to blue
            REqColor = new ManagedFloat(0f);
            GEqColor = new ManagedFloat(0f);
            BEqColor = new ManagedFloat(1f);

            // Set default resource folder to an empty string and filename to store image as "sampleEQ.png"
            ResourceFolder = new ManagedString("");
            FileName = new ManagedString("sampleEQ.png");

            PythonModuleName = new ManagedString("genEQ");
            PythonExprFunction = new ManagedString("genPNG");
        }

        public Expression(float A, float B, float C, float D) : this()
        {
            // Set A, B, C, D so default equation is 1*(1*x+0)^2+0
            AVertStretch.FloatData = A;
            BHorizStretch.FloatData = B;
            CHorizShift.FloatData = C;
            DVertShift.FloatData = D;

            // Generate intial expression x**2
            PyExpression();
        }

        public ManagedString Var;

        public ManagedFloat AVertStretch, BHorizStretch, CHorizShift, DVertShift;

        public ManagedString ExprString, PlotString;

        public void ReflectVertical()
        {
            AVertStretch.FloatData = AVertStretch.FloatData * -1;
            PyExpression();
        }

        public void ReflectHorizontal()
        {
            BHorizStretch.FloatData = BHorizStretch.FloatData * -1;
            PyExpression();
        }

        public abstract string PyExpression();

        public ManagedFloat REqColor, GEqColor, BEqColor;

        public void SetEqColor(float RColor, float GColor, float BColor)
        {
            REqColor.FloatData = RColor;
            GEqColor.FloatData = GColor;
            BEqColor.FloatData = BColor;
        }

        public ManagedString ResourceFolder, FileName;

        private ManagedString PythonModuleName, PythonExprFunction;

        public void GenerateEqImage()
        {
            byte[] bAlpha = System.Text.Encoding.ASCII.GetBytes("0".ToCharArray());
            byte[] bRes = System.Text.Encoding.ASCII.GetBytes("300".ToCharArray());

            char[] result = new char[100];

            byte[] bResult = System.Text.Encoding.ASCII.GetBytes(result);

            PythonFunctions.PyCall(PythonModuleName.ByteData, PythonExprFunction.ByteData,
                               bResult, 8,
                               ExprString.ByteData,
                               REqColor.ByteData, GEqColor.ByteData, BEqColor.ByteData,
                               bAlpha, bRes,
                               ResourceFolder.ByteData, FileName.ByteData);

            for (int j = 0; j < bResult.Length; j++)
            {
                result[j] = (char)bResult[j];
            }

        }
    }
}
