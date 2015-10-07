using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine.UI;
public class PythonFormatter : MonoBehaviour {

    List<GameObject> UserHistory = new List<GameObject>();
    public int UserHistoryMemorySize;
    //upon any change to the input variables we are Instantiating a UserInput Class, populating it, then updating our UserHistory
    private int totalObjects = 0;
    public GameObject VariableA_ref;
    public GameObject VariableB_ref;
    public GameObject VariableC_ref;
    public GameObject VariableD_ref;
    public GameObject Equation_Output_ref;
    public GameObject Plot_Output_ref;
	public GameObject Curve_Output_ref;
    public GameObject DebugEquation;
    public GameObject DebugListCount;
    public GameObject NewEq_prefab_ref;
    public GameObject HoldEquationObjects;
	public int varSize = 100;
	public char[] uResult;

    public GameObject eqChoose;
	
    void Awake(){
		GameMath.PythonFunctions.PyInit ();
		int varSize = 100;
		uResult = new char[varSize];
	}
    public void Modification()
    {
        GameObject NewEquationObject = Instantiate(NewEq_prefab_ref, Vector3.zero, Quaternion.identity) as GameObject;
        NewEquationObject.name = "Equation_" + totalObjects.ToString(); 
        NewEquationObject.GetComponent<UserEquationInput>().Initialize(VariableA_ref.GetComponent<UpdateValue>().ReturnVariable(),
            VariableB_ref.GetComponent<UpdateValue>().ReturnVariable(),
            VariableC_ref.GetComponent<UpdateValue>().ReturnVariable(),
            VariableD_ref.GetComponent<UpdateValue>().ReturnVariable(),
            Color.blue
            );
        totalObjects++;
        NewEquationObject.transform.parent = HoldEquationObjects.transform;
        //here is where we can pull the info for the equations
        string equationRoot = NewEquationObject.GetComponent<UserEquationInput>().AssetFileRootName;
        string equation_plot = equationRoot + "_PLOT.png";
        string equation_EQ = equationRoot + "_EQ.png";
		string equationTest = equationRoot + "_EQ";
		string plotTest = equationRoot + "_PLOT";
        PythonEquationGenerator(NewEquationObject, equation_EQ, equationTest);
        if (NewEquationObject.GetComponent<UserEquationInput>().GeneratePlot)
        {
            PythonPlotGenerator(NewEquationObject, equation_plot, plotTest);            
        }
        else
        {
            //generate and call a null image file to explain to the user that they cannot have A or B = 0
        }

        //update and manage current list
        UserHistory.Add(NewEquationObject);
        UserHistoryManagement();
    }
    private void UserHistoryManagement()
    {
        if (UserHistory.Count > UserHistoryMemorySize)
        {
            Destroy(UserHistory[0]);
            UserHistory.RemoveAt(0);
        }
        //Display Most Recent Equation only for debugging purposes
        DebugEquation.GetComponent<Text>().text = UserHistory[UserHistory.Count - 1].GetComponent<UserEquationInput>().CurrentPythonEq;
        DebugListCount.GetComponent<Text>().text = "List Length: " + UserHistory.Count.ToString();
    }
	private void PythonEquationGenerator(GameObject equationObject, string fileName, string testImageName){

        GameMath.Expression Curve = null;

        switch ((int)eqChoose.GetComponent<UpdateValue>().ReturnVariable())
        {
            case 0:
                {
                    Curve = new GameMath.LinearExpr();
                    break;
                }
            case 1:
                {
                    Curve = new GameMath.QuadExpr();
                    break;
                }
            case 2:
                {
                    Curve = new GameMath.CubeExpr();
                    break;
                }
            case 3:
                {
                    Curve = new GameMath.AbsExpr();
                    break;
                }
            case 4:
                {
                    Curve = new GameMath.SqrtExpr();
                    break;
                }
            case 5:
                {
                    Curve = new GameMath.CbrtExpr();
                    break;
                }
            case 6:
                {
                    Curve = new GameMath.RecipExpr();
                    break;
                }
            default:
                {
                    Curve = new GameMath.LinearExpr();
                    break;
                }
        }


            Curve.AVertStretch.FloatData = equationObject.GetComponent<UserEquationInput>().VarA;
            Curve.BHorizStretch.FloatData = equationObject.GetComponent<UserEquationInput>().VarB;
            Curve.CHorizShift.FloatData = equationObject.GetComponent<UserEquationInput>().VarC;
            Curve.DVertShift.FloatData = equationObject.GetComponent<UserEquationInput>().VarD;

        //Debug.Log(Curve.ExprString.StrData);

            Curve.PyExpression();

            Curve.ResourceFolder.StrData = "Equation Images";
            Curve.FileName.StrData = fileName;

            Curve.SetEqColor(equationObject.GetComponent<UserEquationInput>().CurrentColor.r, equationObject.GetComponent<UserEquationInput>().CurrentColor.g, equationObject.GetComponent<UserEquationInput>().CurrentColor.b);
       
            //Debug.Log(quadCurve.ExprString.StrData);
            
            //create PNG for Equation
            Curve.GenerateEqImage();
        
        /*
            GameMath.QuadExpr quadCurve = new GameMath.QuadExpr();

            quadCurve.AVertStretch.FloatData = equationObject.GetComponent<UserEquationInput>().VarA;
            quadCurve.BHorizStretch.FloatData = equationObject.GetComponent<UserEquationInput>().VarB;
            quadCurve.CHorizShift.FloatData = equationObject.GetComponent<UserEquationInput>().VarC;
            quadCurve.DVertShift.FloatData = equationObject.GetComponent<UserEquationInput>().VarD;

            quadCurve.PyExpression();

            quadCurve.ResourceFolder.StrData = "Equation Images";
            quadCurve.FileName.StrData = fileName;

            quadCurve.SetEqColor(equationObject.GetComponent<UserEquationInput>().CurrentColor.r, equationObject.GetComponent<UserEquationInput>().CurrentColor.g, equationObject.GetComponent<UserEquationInput>().CurrentColor.b);

            Debug.Log(quadCurve.ExprString.StrData);

            //create PNG for Equation
            quadCurve.GenerateEqImage();
        */

		//grab image from file and display
        
		UnityEditor.AssetDatabase.Refresh();

		string rootF = "Equation Images/" + testImageName;
		Sprite myEquation_image = Resources.Load(rootF, typeof(Sprite)) as Sprite;
		//Debug.Log (rootF);
		Equation_Output_ref.GetComponent<Image> ().sprite = myEquation_image;

	}
	private void PythonPlotGenerator(GameObject equationObject, string fileName, string testImageName)
	{
		GameMath.Plot newCurve = new GameMath.Plot ();

        GameMath.Expression newExpr = null;

        switch ((int)eqChoose.GetComponent<UpdateValue>().ReturnVariable())
        {
            case 0:
                {
                    newExpr = new GameMath.LinearExpr();
                    break;
                }
            case 1:
                {
                    newExpr = new GameMath.QuadExpr();
                    break;
                }
            case 2:
                {
                    newExpr = new GameMath.CubeExpr();
                    break;
                }
            case 3:
                {
                    newExpr = new GameMath.AbsExpr();
                    break;
                }
            case 4:
                {
                    newExpr = new GameMath.SqrtExpr();
                    break;
                }
            case 5:
                {
                    newExpr = new GameMath.CbrtExpr();
                    break;
                }
            case 6:
                {
                    newExpr = new GameMath.RecipExpr();
                    break;
                }
            default:
                {
                    newExpr = new GameMath.LinearExpr();
                    break;
                }
        }
        
        newExpr.AVertStretch.FloatData = equationObject.GetComponent<UserEquationInput>().VarA;
        newExpr.BHorizStretch.FloatData = equationObject.GetComponent<UserEquationInput>().VarB;
        newExpr.CHorizShift.FloatData = equationObject.GetComponent<UserEquationInput>().VarC;
        newExpr.DVertShift.FloatData = equationObject.GetComponent<UserEquationInput>().VarD;

        newExpr.PyExpression();

        Debug.Log(newExpr.PlotString.StrData);

        //GameMath.AbsExpr newExpr = new GameMath.AbsExpr(equationObject.GetComponent<UserEquationInput>().VarA, equationObject.GetComponent<UserEquationInput>().VarB, equationObject.GetComponent<UserEquationInput>().VarC, equationObject.GetComponent<UserEquationInput>().VarD);

        //newCurve.Expr.StrData = "1*(1*x+0)**0.5+0";
        //newCurve.Expr.StrData = equationObject.GetComponent<UserEquationInput> ().CurrentPythonEq;
        newCurve.Expr.StrData = newExpr.PlotString.StrData;
        //Debug.Log(newExpr.PlotString.StrData);
        
        //newCurve.XStart.FloatData = 0f;

		GameMath.Axes newGraph = new GameMath.Axes();
		newGraph.AddCurve(newCurve);

		newGraph.ResourceFolder.StrData = "Plot Figures";
		//newGraph.FileName = "newGRAPH.png";
		newGraph.FileName.StrData = fileName;

		newGraph.GenerateGrid();
		newGraph.GeneratePlot(0);
	

		UnityEditor.AssetDatabase.Refresh();
		string rootF = "Plot Figures/" + testImageName+"_AXES";
		Sprite myPlot_image = Resources.Load(rootF, typeof(Sprite)) as Sprite;

		Plot_Output_ref.GetComponent<Image> ().sprite = myPlot_image;

		string rootC = "Plot Figures/" + testImageName+"_0";
		Sprite myCurve_image = Resources.Load(rootC, typeof(Sprite)) as Sprite;

		Curve_Output_ref.GetComponent<Image> ().sprite = myCurve_image;
    }

}
