using UnityEngine;
using System.Collections;

/*
 * Script zur Steuerung des Spielers
 * Methoden:
 * Start -
 * setPlayNum - zum setzen der Variable zur unterscheidung zwischen den Spielern
 * setFlip - Dreht den Spieler um, wird im Director aufgerufen
 * Update - Steuern der Kanone, Instanzieren einer Kugel beim Abfeuern.
*/

public class PlayerControl : MonoBehaviour {

    private float winkel;
    private float power;
    private int munition;
    private int playerNum;
    private bool flip;
    private GameDirector gDir;
    private GameObject gun;
    private GameObject rBullet;
    private GameObject flyingBullet;
    private Rigidbody2D rb;

    void Start()
    {
        winkel = 0;
        munition = 5;
        gun = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        rBullet = Resources.Load<GameObject>("RedBullet");
        gDir = GameObject.Find("SceneScripts").GetComponent<GameDirector>();
        power = 1.0f;
    }

    public void setPlayNum(int pN)
    {
        playerNum = pN;
    }

    public void setFlip()
    {
        flip = true;
        transform.FindChild("base").gameObject.GetComponent<SpriteRenderer>().flipX = true;
        transform.FindChild("base").FindChild("Gun").gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }


	
	void Update ()
    {
            if (gDir.activePlayer == playerNum && gDir.shotInAir == false)
            {
                if(winkel <= 90 && flip == false && Input.GetButton("up") || winkel <= 0 && flip == true && Input.GetButton("down"))
                {
                    winkel += 1;
                    gun.transform.eulerAngles = new Vector3(0, 0, winkel);
                }
                else if(winkel >= 0 && flip == false && Input.GetButton("down")|| winkel >= -90 && flip == true && Input.GetButton("up"))
                {
                    winkel -= 1;
                    gun.transform.eulerAngles = new Vector3(0, 0, winkel);
                }
                else if (Input.GetButton("fire")&& power <4.0f)
                {
                power = power + Time.deltaTime;
                }
                else if (Input.GetButtonUp("fire"))
                {
                    Instantiate(rBullet, gun.transform.parent.position, gun.transform.rotation);
                    flyingBullet = GameObject.Find("RedBullet(Clone)");
                    if (flip) flyingBullet.transform.Rotate(new Vector3(0, 0, 180));
                    flyingBullet.transform.Rotate(new Vector3(0, 0, -90));
                    flyingBullet.transform.Translate(0, 1, 0);
                    rb = flyingBullet.GetComponent<Rigidbody2D>();
                    print("power: "+power);
                    rb.AddRelativeForce(new Vector2(0, 200*power));
                    gDir.shotInAir = true;
                    power = 1.0f;
                }

            }
	}
}
