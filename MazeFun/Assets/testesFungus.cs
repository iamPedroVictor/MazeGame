using UnityEngine;
using System.Collections;
using Fungus;

public class testesFungus : MonoBehaviour {

    public Flowchart flowChart;
    public string nameB;

	// Use this for initialization
	void Start () {
        flowChart = GetComponentInChildren<Flowchart>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (nameB == "Cube")
        {
            if (Input.GetKey(KeyCode.D))
            {
                flowChart.SendFungusMessage("StartBlock");
            }
        }else if (nameB == "Cube 1") {
            if (Input.GetKey(KeyCode.A))
            {
                flowChart.SendFungusMessage("StartBlock");
            }
        }else {
            if (Input.GetKey(KeyCode.S))
            {
                flowChart.SendFungusMessage("StartBlock");
            }
        }
	
	}
}
