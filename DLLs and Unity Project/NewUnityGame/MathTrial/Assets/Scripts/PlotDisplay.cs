using UnityEngine;
using System.Collections;

public class PlotDisplay : MonoBehaviour {

    public Sprite[] plotSprites;
    public int counter = 0;
    public Color plotColor;
    public float xPoint;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
			GameMath.Plot newCurve = new GameMath.Plot();
            
			//newCurve.Expr = "x**2";

			GameMath.Axes newGraph = new GameMath.Axes();
			newGraph.AddCurve(newCurve);

			newGraph.ResourceFolder.StrData = "Plot Figures";
			newGraph.FileName.StrData = "newGRAPH.png";

			newGraph.GenerateGrid();
			newGraph.GeneratePlot(0);

            UnityEditor.AssetDatabase.Refresh();

            plotSprites = Resources.LoadAll<Sprite>("Plot Figures");

            gameObject.GetComponent<SpriteRenderer>().sprite = plotSprites[counter];
        }
	}
}
