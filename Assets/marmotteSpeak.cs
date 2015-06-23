using UnityEngine;
using System.Collections;

public class marmotteSpeak : MonoBehaviour {

    //temps d apparition du texte a l ecran
    public float timeShown = 5.0F;

    private float cpt;

	// Use this for initialization
	void Start () {
        cpt = 0.0F;
	}
	
	// Update is called once per frame
	void Update () {
        cpt += Time.deltaTime;
        if (cpt >= timeShown)
        {
            GameObject canvas = GameObject.FindGameObjectWithTag("marmotteUI");
            Destroy(canvas);
        }
	}
}
