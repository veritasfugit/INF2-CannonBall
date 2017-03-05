using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script welches mit dem gemArray zusammenarbeiten sollte zur Anzeige der Stärke eines Schusses - WIP 
*/
public class gemControl : MonoBehaviour {

    public Sprite[] gemColors;
    private SpriteRenderer sRen;

	void Start () {
        sRen = GetComponent<SpriteRenderer>();
        sRen.sprite = gemColors[0];

    }

    public void setCol(int c)
    {
        sRen.sprite = gemColors[c];
    }

	void Update () {
		
	}
}
