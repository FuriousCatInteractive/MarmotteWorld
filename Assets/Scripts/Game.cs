using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    // First riddle
    public GameObject firstPipe;
    public GameObject secondPipe;

    // Second riddle
    public GameObject tank;

    int riddle = 0;

	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
        switch (riddle)
        {
            case 0:
                {
                    firstRiddle();
                    break;
                }
            case 1:
                {
                    secondRiddle();
                    break;
                }
            default :
                {
                    break;
                }
        }
	}

    // Il manque 4/9 de tuyaux il faut utiliser un tuyau de 1/3 et 2/18
    bool firstRiddle()
    {
        if (firstPipe.GetComponent<MeshRenderer>().enabled && secondPipe.GetComponent<MeshRenderer>().enabled)
        {
            print("First end");
            ++riddle;
            return true;
        }
        return false;
    }

    // Un reservoir de 450L on doit en le remplir a 30% => 135L
    bool secondRiddle()
    {
        if (tank.GetComponent<WaterPipe>().size == 135)
        {
            print("Second end");
            ++riddle;
            return true;
        }
        else
        {
            tank.GetComponent<WaterPipe>().emptyTank();
        }
        return false;
    }
}
