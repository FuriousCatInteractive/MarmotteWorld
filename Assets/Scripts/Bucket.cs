using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {
    public bool isFull = false;
    public float size = 1;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void FillBucket()
    {
        isFull = true;
        var tmp = gameObject.GetComponentInChildren<UnityStandardAssets.Water.Water>();
        //tmp.enabled = true;
        tmp.GetComponentInParent<MeshRenderer>().enabled = true;
    }

    public void EmptyBucket()
    {
        isFull = false;
        var tmp = gameObject.GetComponentInChildren<UnityStandardAssets.Water.Water>();
        //tmp.enabled = false;
        tmp.GetComponentInParent<MeshRenderer>().enabled = false;
    }
}
