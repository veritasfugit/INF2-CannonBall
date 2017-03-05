using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script zum Tracken des Lebens des Charakters und als Signalgeber an den Director zum beenden des Spiels. WIP
 * Im Aktuellen Stand nicht genutzt, da ich das Spiel einfach nur beende bei einem Treffer. Und ich noch einige andere Strukturelle änderungen
 * vornehmen müsste wenn ich es mit diesem Script lenke.
*/

public class PlayerHealth : MonoBehaviour {

    private int health;
    private GameDirector gDir;
	
	void Start () {
        health = 1;
        gDir = GameObject.Find("SceneScripts").GetComponent<GameDirector>();
    }
	
	void Update () {
		
	}

    public void gotHit()
    {
        print("hit!");
        health -= health;
        if (health <= 0)
        {
            gDir.endMatch();
            print("end");
        }
    }

    void reset()
    {
        health = 1;
    }
}
