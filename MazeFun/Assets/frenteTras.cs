using UnityEngine;
using System.Collections;

public class frenteTras : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
        Vector3 toTarget = (target.position - transform.position).normalized;
        if (Vector3.Dot(toTarget, transform.forward) > 0)
        {
            Debug.Log("O Alvo"+ target.name + "esta na frente");
        }
        else {
            Debug.Log("O alvo "+ target.name +" esta atras");
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
