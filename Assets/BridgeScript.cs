using UnityEngine;
using System.Collections;

public class BridgeScript : MonoBehaviour {

    public float poidsSurPont = 0;
    public FalconSpringedBody springedBody;
    private float oldPoids;

	// Use this for initialization
	void Start () {
        springedBody = GetComponent<FalconSpringedBody>();
        oldPoids = poidsSurPont;
	}
	
	// Update is called once per frame
	void Update () {

        
        if (poidsSurPont != oldPoids)
        {
            springedBody.springPos = new Vector3(springedBody.springPos.y, springedBody.springPos.y - 20.0F, springedBody.springPos.z);
            oldPoids = poidsSurPont;
        }
        
	
	}

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.CompareTag("weightedCube"))
        {
            Debug.Log("---------->poids en + " + collider.GetComponent<Rigidbody>().mass);
            poidsSurPont += collider.GetComponent<Rigidbody>().mass / 3;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("weightedCube"))
        {
            Debug.Log("---------->poids en moim=ns " + collider.GetComponent<Rigidbody>().mass);
            poidsSurPont -= collider.GetComponent<Rigidbody>().mass / 3;
        }
    }
}
