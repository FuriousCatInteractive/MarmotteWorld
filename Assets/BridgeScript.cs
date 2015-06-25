using UnityEngine;
using System.Collections;

public class BridgeScript : MonoBehaviour {

    public float poidsSurPont = 0;
    public float poidsCorrect = 50.0f;
    public float hauteurCorrecte = -2.82f;
    public float vitesse = 5.0f;

    private Transform bridgeTransform;
    private float posInit;
    private Vector3 posArrivee;

    public float delta = 0.7F;

	// Use this for initialization
	void Start () {
        bridgeTransform = transform.root;
        posInit = bridgeTransform.position.y;
        posArrivee = bridgeTransform.position;
	}
	
	// Update is called once per frame
	void Update () {

        bridgeTransform.position = Vector3.Lerp(transform.position, posArrivee, vitesse * Time.deltaTime * 0.1f);  
 	}

    void UpdateTargetHeight()
    {
        float y = (poidsSurPont * (hauteurCorrecte - posInit)) / poidsCorrect;
        posArrivee = new Vector3(bridgeTransform.position.x, y + posInit, bridgeTransform.position.z);
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("weightedCube"))
        {
            //Debug.Log("---------->poids en + " + collider.GetComponent<Rigidbody>().mass);
            poidsSurPont += collider.GetComponent<Rigidbody>().mass/2;
            collider.GetComponent<Rigidbody>().useGravity = false;
            collider.transform.SetParent(bridgeTransform);
            UpdateTargetHeight();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("weightedCube"))
        {
            //Debug.Log("---------->poids en moim=ns " + collider.GetComponent<Rigidbody>().mass);
            poidsSurPont -= collider.GetComponent<Rigidbody>().mass/2;

            collider.transform.SetParent(null);

            UpdateTargetHeight();
        }
    }
}
