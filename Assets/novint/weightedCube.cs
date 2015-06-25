using UnityEngine;
using System.Collections;


public class weightedCube : MonoBehaviour
{
    private Rigidbody rigidbody;
    private BridgeScript bridge;

    public FalconSpringedBody springedBody;          

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        bridge = GameObject.FindGameObjectWithTag("MovableBridge").GetComponent<BridgeScript>();
        springedBody = GameObject.FindGameObjectWithTag("MovableBridge").GetComponent<FalconSpringedBody>(); 
	}
	
	// Update is called once per frame
	void Update () {     
     
	
	}


}
