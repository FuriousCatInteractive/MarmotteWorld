using UnityEngine;
using System.Collections;

public class BinaryDetector : MonoBehaviour {
    public bool activate = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("binaryCube")) 
        {
            activate = true;
        }
        else
        {
            print("Test");
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (true)
        {
            activate = true;
        }
        else
        {
            print("Test");
        }  
    }
}
