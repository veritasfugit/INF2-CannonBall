using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script zur Auswahl eines Zufälligen Levels und zur Positionierung der Spieler in selbigem
*/

public class LevelChange : MonoBehaviour {

    private GameObject[] levels;
    private GameObject p1;
    private GameObject p2;

	void Start () {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
	}
	
	void Update () {
		
	}

    public void newLevel()
    {
        int rand = (int)Random.Range(0.0f, 3.0f);
        print(rand);
        if(rand >= 2)
        {
            transform.FindChild("Level3").gameObject.SetActive(true);
            p1.transform.position = GameObject.Find("Level3").transform.FindChild("P1Start").transform.position;
            p2.transform.position = GameObject.Find("Level3").transform.FindChild("P2Start").transform.position;
        }
        else if(rand >= 1)
        {
            transform.FindChild("Level2").gameObject.SetActive(true);
            p1.transform.position = GameObject.Find("Level2").transform.FindChild("P1Start").transform.position;
            p2.transform.position = GameObject.Find("Level2").transform.FindChild("P2Start").transform.position;
        }
        else
        {
            transform.FindChild("Level1").gameObject.SetActive(true);
            p1.transform.position = GameObject.Find("Level1").transform.FindChild("P1Start").transform.position;
            p2.transform.position = GameObject.Find("Level1").transform.FindChild("P2Start").transform.position;
        }
    }
}
