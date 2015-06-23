using UnityEngine;
using System.Collections;

public class WaterPipe : MonoBehaviour {
    public float size;

	// Use this for initialization
	void Start () {
        size = 0;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bucket"))
        {
            var tmp = other.GetComponentInChildren<Bucket>();
            if (tmp.isFull)
            {
                size += tmp.size;
                other.GetComponentInChildren<Bucket>().EmptyBucket();
                print(size);
            } 
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
