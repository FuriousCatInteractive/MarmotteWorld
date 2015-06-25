using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    // First riddle
    public GameObject firstPipe;
    public GameObject secondPipe;

    // Second riddle
    public GameObject tank;

    public GameObject waterDoor;

    public Collider thirdRiddleBlocker;

    int riddle = 0;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<marmotteSpeak>().marmotteSays("Salut! Je suis Fluffy la marmotte, je vais t'aider à t'échapper d'ici. Commence par réparer les tuyaux avec ceux posés à côté. La longueur à réparer est de 4/9.", 10.0F);            
           
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
            case 2:
                {
                    thirdRiddle();
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
            GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<marmotteSpeak>().marmotteSays("Bien joué ! Maintenant il faut remplir le réservoir de 450L à 40% avec les seaux d'eau, cela permettera d'ouvrir la porte hydrolique.", 10.0F);            
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
            GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<marmotteSpeak>().marmotteSays("Super ! La porte est ouverte! Allons dans l'autre salle.", 6.0F);
            waterDoor.GetComponent<WaterDoor>().openDoor();
           return true;
        }
        else if (tank.GetComponent<WaterPipe>().size > 180)
        {
            tank.GetComponent<WaterPipe>().emptyTank();
        }
        return false;
    }

    bool thirdRiddle()
    {
        BridgeScript script = GameObject.FindGameObjectWithTag("MovableBridge").GetComponentInChildren<BridgeScript>();
        Debug.Log("pois sur pont " + script.poidsSurPont + " poid s correc " + script.poidsCorrect);
        if(script.poidsSurPont == script.poidsCorrect )
        {
            print("Third end");
            ++riddle;
            GameObject.FindGameObjectWithTag("marmotteUI").GetComponent<marmotteSpeak>().marmotteSays("Nickel!! On peut maintenant traverser le pont!!", 6.0F);
            thirdRiddleBlocker.enabled = false;
        }
        return false;
    }
}
