using UnityEngine;
using System.Collections;

public class BinaryDoor : MonoBehaviour {
    public GameObject[] solve;
    private Animation anim;
    private bool isOpen = false;
    public AudioClip doorSound;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        bool tmp = true;
        for (int i = 0; i < solve.Length; ++i)
        {
            var test = solve[i].GetComponent<BinaryDetector>().activate;
            if (!solve[i].GetComponent<BinaryDetector>().activate)
            {
                tmp = false;
            }
        }
        if (tmp && !isOpen)
        {
            GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<marmotteSpeak>().marmotteSays("Super! La porte est ouverte! vite allons dehors!!", 10.0F);            
            GetComponent<AudioSource>().PlayOneShot(doorSound);
            anim.Play("open");
            isOpen = true;
        }
	}
}
