using UnityEngine;
using System.Collections;

public class BinaryDoor : MonoBehaviour {
    public GameObject[] solve;
    private Animation anim;
    private bool isOpen = false;
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
            anim.Play("open");
            isOpen = true;
        }
	}
}
