using UnityEngine;
using System.Collections;

public class WaterPipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bucket"))
        {
            print("caca");
            other.GetComponentInChildren<Bucket>().EmptyBucket();
            //other.GetComponent<Bucket>().EmptyBucket();
        }
        else
        {
            print("Test");
        }
    }
}
