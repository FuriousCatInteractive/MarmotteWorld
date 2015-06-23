using UnityEngine;
using System.Collections;

public class WaterPipe : MonoBehaviour {
    public int size;

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

    public void emptyTank()
    {
        size = 0;
    }
}
