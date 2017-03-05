using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simples Script zur deaktivierung des Spielertags nach 2 Sekunden
*/


public class PlayerTagDeac : MonoBehaviour {

    private float Ttimer;

    // Use this for initialization
    void Start () {
        Ttimer = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(Ttimer > 0)
        {
            Ttimer = Ttimer - Time.deltaTime;
        }else
        {
            Ttimer = 2;
            gameObject.SetActive(false);
        }
	}
}
