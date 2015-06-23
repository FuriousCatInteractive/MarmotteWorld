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

    /**
     * taille des pipe em fction du scale
     * 
     * resultat
     * 4/9 == 2.5
     *
     * n=bonnes reponses
     * 2/18 == 0.625
     * 1/3 == 1,875
     *
     * autres pipes inutiles
     * 2/7 == 1.607
     * 3/6 == 2.81
     * 2/9 == 1.25
     * 
     * */
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

    // Un reservoir de 450L on doit en le remplir a 40% => 180L
    bool secondRiddle()
    {
        if (tank.GetComponent<WaterPipe>().size == 180)
        {
            print("Second end");
            ++riddle;
            return true;
        }
        else if (tank.GetComponent<WaterPipe>().size > 180)
        {
            tank.GetComponent<WaterPipe>().emptyTank();
        }
        return false;
    }
}
