using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour {
    public float minRange;
    public float maxRange;
    private float timer;
	// Use this for initialization
	void Start () {
        StartCoroutine(Blink());
	}

    IEnumerator Blink()
    {
        while (true)
        {
            timer = Random.Range(minRange, maxRange);
            yield return new WaitForSeconds(timer);
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
