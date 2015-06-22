using UnityEngine;
using System.Collections;

public class Waterfall : MonoBehaviour {

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
            print("pipi");
            other.GetComponentInChildren<Bucket>().FillBucket();
            //other.GetComponent<Bucket>().FillBucket();
        }
        else
        {
            print("Test");
        }
    }
}
