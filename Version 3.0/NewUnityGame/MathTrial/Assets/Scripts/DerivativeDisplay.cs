using UnityEngine;
using System.Collections;
using UnityEditor;

public class DerivativeDisplay : MonoBehaviour {

    public Sprite[] dSprites;
    public int counter = 10;
    public Color dEqColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int varSize = 100;
            char[] uResult = new char[varSize];

            //CallCPPFunc.CallCPPFunc.PyCallSharp("functions", "pydiff", "x**2-5".ToCharArray(), "x".ToCharArray(), uResult);

            //CallCPPFunc.CallCPPFunc.PyCallGenEqSharp("genEQ", "genPNG", uResult, dEqColor.r.ToString().ToCharArray(), dEqColor.g.ToString().ToCharArray(), dEqColor.b.ToString().ToCharArray(), dEqColor.a.ToString().ToCharArray(), "300".ToCharArray(), "Equation Images".ToCharArray(), "dEq.png".ToCharArray(), uResult);

            counter = 0;

            UnityEditor.AssetDatabase.Refresh();

            dSprites = Resources.LoadAll<Sprite>("Equation Images");

            gameObject.GetComponent<SpriteRenderer>().sprite = dSprites[counter];

        }
    
	}

}
