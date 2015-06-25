using UnityEngine;
using System.Collections;

public class fluffyBox : MonoBehaviour {

    public string text;
    private bool playOnce;

	// Use this for initialization
	void Start () {
        playOnce = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && playOnce)
        {
            playOnce = false;
            GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<marmotteSpeak>().marmotteSays(text, 10.0F);            
           
        }
    }


}
    