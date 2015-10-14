using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System;

public class EqDisplay : MonoBehaviour {

    public Sprite[] eqSprites;
    public int counter = 0;
    public Color origEqColor;
    
	// Use this for initialization
	void Start () {
        int varSize = 100;
        char[] uResult = new char[varSize];

		// Initialize the Python Interpreter
		GameMath.PythonFunctions.PyInit ();

		// Create a quadratic expression initialized to 1*(1*x - 2)**2 + 1
		GameMath.QuadExpr quadCurve = new GameMath.QuadExpr(1, 1, 2, 1);

		quadCurve.ResourceFolder.StrData = "Equation Images";
		quadCurve.FileName.StrData = "newEQ.png";

		quadCurve.SetEqColor (1, 1, 0);

		quadCurve.GenerateEqImage();

		//Debug.Log (quadCurve.REqColor.ToString ());//quadCurve.ExprString);

		//Debug.Log (System.Environment.Version);

        //CallCPPFunc.CallCPPFunc.PyCallGenEqSharp("genEQ", "genPNG", quadCurve.ExprString.ToCharArray(), origEqColor.r.ToString().ToCharArray(), origEqColor.g.ToString().ToCharArray(), origEqColor.b.ToString().ToCharArray(), origEqColor.a.ToString().ToCharArray(), "300".ToCharArray(), "Equation Images".ToCharArray(), "test1.png".ToCharArray(), uResult);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter = 1;
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            origEqColor.r = UnityEngine.Random.value;
            origEqColor.g = UnityEngine.Random.value;
            origEqColor.b = UnityEngine.Random.value;
            char[] uResult = new char[100];


            //CallCPPFunc.CallCPPFunc.PyCallGenEqSharp("genEQ", "genPNG", "x**2-5".ToCharArray(), origEqColor.r.ToString().ToCharArray(), origEqColor.g.ToString().ToCharArray(), origEqColor.b.ToString().ToCharArray(), origEqColor.a.ToString().ToCharArray(), "300".ToCharArray(), "Equation Images".ToCharArray(), "test1.png".ToCharArray(), uResult);
        }

        UnityEditor.AssetDatabase.Refresh();

        eqSprites = Resources.LoadAll<Sprite>("Equation Images");

        gameObject.GetComponent<SpriteRenderer>().sprite = eqSprites[counter];

        
	
	}
}
