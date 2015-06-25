using UnityEngine;
using System.Collections;

public class fluffyBox : MonoBehaviour {

    public string text;

	// Use this for initialization
	void Start () {
       // text = "caca";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<marmotteSpeak>().marmotteSays(text, 10.0F);            
           
        }
    }


}
    