using UnityEngine;
using System.Collections;

public class WaterDoor : MonoBehaviour {

    bool isOpen = false;
    private Animation anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openDoor()
    {
        if (!isOpen)
        {
            anim.Play("open");
            isOpen = true;
        }
    }
}
