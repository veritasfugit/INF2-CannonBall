using UnityEngine;
using System.Collections;

/*
 * HauptScript um den Spielfluss zu Steuern
 * Methoden: 
 * Start - setup des Spiels beim Spielstart
 * nextTurn - um nach einem Schuss den Spieler zu wechseln, stößt ausserdem das ende des spiels an wenn die Kugel einen Spieler getroffen hat
 * newMap - einfache Referenz zum Script für die Levelauswahl
 * endMatch - Das Ende des Spiels
*/

public class GameDirector : MonoBehaviour {

    public int activePlayer = 0;
    public int collisionChecks = 0;
    public int maxPlayer = 2;
    public bool shotInAir;
    public bool windchange = true;
    public bool hit = false;

	void Start ()
    {
        //Hier könnte ich noch mehr Spieler einfügen
        //Flexibler Code wäre schön
        GameObject.Find("Player1").GetComponent<PlayerControl>().setPlayNum(1);
        GameObject.Find("Player2").GetComponent<PlayerControl>().setPlayNum(2);
        GameObject.Find("Player2").GetComponent<PlayerControl>().setFlip();
        activePlayer = 1;
        newMap();
    }

    public void nextTurn()
    {
        print("NextTurn");
        if (hit == true)
        {
            endMatch();
        }
        else
        {
            if (activePlayer >= maxPlayer)
            {
                print("piep");
                activePlayer = 1;
                windchange = true;
                GameObject.Find("UI").transform.FindChild("PTag1").gameObject.SetActive(true);
            }
            else
            {
                activePlayer += 1;
                windchange = true;
                GameObject.Find("UI").transform.FindChild("PTag2").gameObject.SetActive(true);
            }
        }
    }

    private void newMap()
    {
        GameObject.Find("GameLevel").GetComponent<LevelChange>().newLevel();
    }
    
    public void endMatch()
    {
        if(activePlayer == 1)
        {
            //hier einblendungen und mapchange und health reset
            GameObject.Find("UI").transform.FindChild("PTag1").gameObject.SetActive(true);
            GameObject.Find("UI").transform.FindChild("Wins").gameObject.SetActive(true);

        }
        else if(activePlayer == 2)
        {
            //hier einblendungen und mapchange und health reset
            //GameObject.Find("PTag2").SetActive(true);
            GameObject.Find("UI").transform.FindChild("PTag2").gameObject.SetActive(true);
            GameObject.Find("UI").transform.FindChild("Wins").gameObject.SetActive(true);

        }
        else
        {
            print("error - unknown player");
        }
        activePlayer = 0;
    }
}
