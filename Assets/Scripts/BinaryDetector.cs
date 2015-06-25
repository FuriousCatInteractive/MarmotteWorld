using UnityEngine;
using System.Collections;

public class BinaryDetector : MonoBehaviour {
    public bool activate = false;
    public AudioClip cubeSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("binaryCube")) 
        {
            if (!activate)
            {
                GetComponent<AudioSource>().PlayOneShot(cubeSound);
            }
            activate = true;
        }
        else
        {
//            print("Test");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("binaryCube"))
        {
            activate = false;
        }
    }

}
