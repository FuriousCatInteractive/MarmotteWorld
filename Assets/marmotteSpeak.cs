using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class marmotteSpeak : MonoBehaviour {

    //temps d apparition du texte a l ecran
    public float timeShown = 10.0F;
    public string currentText;
    public float timeAssociate;

    private Canvas canvas;
    private float cpt;

    public AudioClip nekoNya;

	// Use this for initialization
	void Start () {
        cpt = 0.0F;
        GetComponent<AudioSource>().PlayOneShot(nekoNya);
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

        bool[] buttons;
        FalconUnity.getFalconButtonStates(0, out buttons);

        //boutton du milieu => id 0
        if (buttons[2])
        {
            marmotteSays(currentText, timeAssociate);
        }
	}

    public void reinitialiseCpt()
    {
        cpt = 0.0F;
    }

    public void marmotteSays(string text, float time)
    {
        currentText = text;
        timeAssociate = time;

        reinitialiseCpt();
        canvas.enabled = true;
        Debug.Log("coucou");
        GetComponent<AudioSource>().PlayOneShot(nekoNya);
        GameObject.FindGameObjectWithTag("marmotteText").GetComponent<Text>().text = text;
        timeShown = time;
        
    }
}
