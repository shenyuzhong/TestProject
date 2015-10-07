using System;
using System.Collections.Generic;
using System.Text;

namespace GameMath
{
    public class Axes
    {
        public Axes()
        {
            // Initialize an empty list to hold curves
            numCurves = 0;
            Curves = new List<Plot>();

            // Set default axis color to Blue
            RAxisColor = new ManagedFloat(0f);
            GAxisColor = new ManagedFloat(0f);
            BAxisColor = new ManagedFloat(1f);

            // Set alpha to 1 for a 
            AAxisColor = new ManagedFloat(1f);

            // Set default resource folder to an empty string and filename to store image as "sample.png"
            ResourceFolder = new ManagedString("");
            FileName = new ManagedString("sample.png");

            // Set bounds for axes
            XL = new ManagedFloat(-10f);
            XU = new ManagedFloat(10f);
            YL = new ManagedFloat(-10f);
            YU = new ManagedFloat(10f);

            // Set strings for Python call
            PythonModuleName = new ManagedString("genPLOT");
            PythonAxesFunction = new ManagedString("genAXES");
            PythonPlotFunction = new ManagedString("genPLOT");
        }

        public List<Plot> Curves;
        int numCurves;

        public void AddCurve(Plot newCurve)
        {
            numCurves++;
            Curves.Add(newCurve);
        }

        public ManagedFloat RAxisColor, GAxisColor, BAxisColor, AAxisColor;
        
        public void SetAxisColor(float RColor, float GColor, float BColor)
        {
            RAxisColor.FloatData = RColor;
            GAxisColor.FloatData = GColor;
            BAxisColor.FloatData = BColor;
        }

        public ManagedString ResourceFolder, FileName;

       public ManagedFloat XL, XU, YL, YU;

        public void SetAxesBounds(float XLower, float XUpper, float YLower, float YUpper)
        {
            XL.FloatData = XLower;
            XU.FloatData = XUpper;
            YL.FloatData = YLower;
            YU.FloatData = YUpper;
        }

        public ManagedString PythonModuleName, PythonAxesFunction, PythonPlotFunction;

        public void GenerateGrid()
        {
            byte[] bRes = System.Text.Encoding.ASCII.GetBytes("300".ToCharArray());
            string[] parts = FileName.StrData.Split('.');
            string axesFile = parts[0] + "_AXES." + parts[1];
            byte[] byte_fileName = Encoding.ASCII.GetBytes(axesFile.ToCharArray());

            char[] result = new char[100];

            byte[] bResult = System.Text.Encoding.ASCII.GetBytes(result);

            PythonFunctions.PyCall(PythonModuleName.ByteData, 
                               PythonAxesFunction.ByteData, 
                               bResult, 11, 
                               XL.ByteData, XU.ByteData, YL.ByteData, YU.ByteData, 
                               RAxisColor.ByteData, GAxisColor.ByteData, BAxisColor.ByteData, 
                               AAxisColor.ByteData, bRes, 
                               ResourceFolder.ByteData, byte_fileName);

            for (int j = 0; j < bResult.Length; j++)
            {
                result[j] = (char)bResult[j];
            }
        }

        public void GeneratePlot(int curveNum)
        {
            byte[] bxPoint = Encoding.ASCII.GetBytes("2".ToCharArray());
            byte[] bAlpha = Encoding.ASCII.GetBytes("1".ToCharArray());
            byte[] bRes = Encoding.ASCII.GetBytes("300".ToCharArray());
            string[] parts = FileName.StrData.Split('.');
            string curveFile = parts[0] + "_" + curveNum + "." + parts[1];
            byte[] bFileName = Encoding.ASCII.GetBytes(curveFile.ToCharArray());

            char[] result = new char[100];

            byte[] bResult = Encoding.ASCII.GetBytes(result);

            PythonFunctions.PyCall(PythonModuleName.ByteData, PythonPlotFunction.ByteData, 
                               bResult, 13, 
                               Curves[curveNum].Expr.ByteData, Curves[curveNum].Var.ByteData, 
                               Curves[curveNum].XStart.ByteData, Curves[curveNum].XStop.ByteData, 
                               Curves[curveNum].XStep.ByteData, 
                               bxPoint, 
                               Curves[curveNum].RPlotColor.ByteData, Curves[curveNum].GPlotColor.ByteData, 
                               Curves[curveNum].BPlotColor.ByteData, bAlpha, 
                               bRes, 
                               ResourceFolder.ByteData, bFileName);

            for (int j = 0; j < bResult.Length; j++)
            {
                result[j] = (char)bResult[j];
            }
        }
    }
    
}
