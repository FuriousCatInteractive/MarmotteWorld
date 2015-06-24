using UnityEngine;
using System.Collections;

public class BucketWeight : MonoBehaviour {

    private Transform transform;
    private bool taken;
    private PrenableObject prenableScript;
    private Bucket bucketScript;
    private float offset;
    private float size;
    private Vector3 gravityFull;
    private Vector3 gravityEmpty;

	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        bucketScript = GetComponentInChildren<Bucket>();
        prenableScript = GetComponent<PrenableObject>();
        size = transform.localScale.y;
        gravityEmpty = new Vector3(0, -3.0F * size, 0);
        gravityFull  = new Vector3(0, -5.4F * size, 0);

        Debug.Log(name + "--> " + prenableScript.m_Gravity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void FixedUpdate()
    {
        //Debug.Log("avant " + prenableScript.m_Gravity.y);
        
        if (bucketScript.isFull)
            prenableScript.m_Gravity = gravityFull;
        else
            prenableScript.m_Gravity = gravityEmpty;

        //Debug.Log("qpres " + prenableScript.m_Gravity.y);
       

    }
}
