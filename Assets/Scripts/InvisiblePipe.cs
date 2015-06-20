using UnityEngine;
using System.Collections;

public class InvisiblePipe : MonoBehaviour {
    public int numerator;
    public int denominator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pipe") && numerator == other.GetComponent<Pipe>().numerator && denominator == other.GetComponent<Pipe>().denominator)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GameObject.Destroy(other.gameObject);
        }
        else
        {
            print("Test pipe");
        }
    }
}
