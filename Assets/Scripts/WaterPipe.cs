using UnityEngine;
using System.Collections;

public class WaterPipe : MonoBehaviour {
    public float size;
    public GameObject water;
    private Vector3 minPosition;
    public double test = 0;

	// Use this for initialization
	void Start () {
        size = 0;
        minPosition = water.transform.localPosition;
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
                print("augmentation = " + size * 2.2f / 450f);
                test = size * 2.2 / 450;
                Debug.Log(test);
                water.transform.Translate(new Vector3(0f, size * 2.2f / 450f, 0f));
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
        water.transform.Translate(minPosition);
    }
}
