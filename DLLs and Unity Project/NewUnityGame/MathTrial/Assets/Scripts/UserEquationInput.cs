using UnityEngine;
using System.Collections;
using System;

public class UserEquationInput : MonoBehaviour {

        public GameObject MyEquation;
        public GameObject MyPlot;
        private string currentPythonEq;//hold the python formatted equation IE "+-a*(+-b*x-c)**2 +d"
        private Color currentColor;
        private float varA;
        private float varB;
        private float varC;
        private float varD;
        private string assetFileRootName;
        private bool generatePlot;

        public bool GeneratePlot
        {
            get { return generatePlot; }
            set { generatePlot = value; }
        }

        public string AssetFileRootName
        {
            get { return assetFileRootName; }
            set { assetFileRootName = value; }
        }
        public float VarA
        {
            get { return varA; }
            set { varA = value; }
        }
        public float VarB
        {
            get { return varB; }
            set { varB = value; }
        }
        public float VarC
        {
            get { return varC; }
            set { varC = value; }
        }
        public float VarD
        {
            get { return varD; }
            set { varD = value; }
        }
        public Color CurrentColor
    {
        get { return currentColor; }
        set { currentColor = value; }
    }
        public string CurrentPythonEq
    {
        get { return currentPythonEq; }
        set { currentPythonEq = value; }
    }
        public void Initialize(float vA, float vB, float vC, float vD, Color myColor)
        {
            this.VarA = vA;
            this.VarB = vB;
            this.VarC = vC;
            this.VarD = vD;
            this.CurrentColor = myColor;
            this.CurrentPythonEq = buildEquation(vA,vB,vC,vD);
            this.AssetFileRootName = buildName();
            this.GeneratePlot = EquationCheck();
            //string equationPNG = AssetFileRootName + "_EQ";
            //string plotPNG = AssetFileRootName + "_PLOT";
            //This is where we will call the python code to spit out both images
            //python equation
            //python plot
            
        }
        /// <summary>
        /// Build and return a string that is formatted for Python
        /// </summary>
        /// <param name="va"></param>
        /// <param name="vb"></param>
        /// <param name="vc"></param>
        /// <param name="vd"></param>
        /// <returns></returns>
        private string buildEquation(float va,float vb,float vc,float vd){
            string newString = va.ToString() + "*(" + vb.ToString() + "*x-" + vc.ToString() + ")**2+" + vd.ToString();
            return newString;
        }
        private bool EquationCheck()
        {
            if (VarA == 0 || VarB == 0)
            {
                return false;
            }
            else
            {
                //if (VarA != 0 && VarB != 0)
                //{
                //    return true;
                //}
			return true;
            }
        }
        private string buildName()
        {
            DateTime current = DateTime.Now;
            UnityEngine.Random.seed = (Int32)current.Ticks;
            float randomVar = UnityEngine.Random.value;
			randomVar = Mathf.Round( randomVar * 1000000f);
            return randomVar.ToString();
        }

}
