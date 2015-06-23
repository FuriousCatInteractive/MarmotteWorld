using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class marmotteSpeak : MonoBehaviour {

    //temps d apparition du texte a l ecran
    public float timeShown = 5.0F;

    private Canvas canvas;
    private float cpt;

	// Use this for initialization
	void Start () {
        cpt = 0.0F;
        canvas = GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<Canvas>();
        canvas.enabled = false;
 	}
	
	// Update is called once per frame
	void Update () {
        cpt += Time.deltaTime;
        if (cpt >= timeShown)
        {
            canvas.enabled = false;
        }
	}

    public void reinitialiseCpt()
    {
        cpt = 0.0F;
    }

    public void marmotteSays(string text, float time)
    {
        reinitialiseCpt();
        canvas.enabled = true;
        GameObject.FindGameObjectWithTag("marmotteText").GetComponent<Text>().text = text;
        timeShown = time;
    }
}
