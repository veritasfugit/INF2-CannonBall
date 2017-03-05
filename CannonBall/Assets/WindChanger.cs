using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script zur änderung der Windrichtung und ausrichtung des UI Pfeils zur Anzeige derselben.
*/

public class WindChanger : MonoBehaviour {

    private GameDirector gDir;
    public float windDirection;
    public float xPow;
    public float yPow;

    // Use this for initialization
    void Start () {
        gDir = GameObject.Find("SceneScripts").GetComponent<GameDirector>();
    }
	
    void Update()
    {
        if(gDir.windchange == true)
        {
            windDirection = Random.Range(0.0f, 360.0f);
            xPow = Mathf.Cos(windDirection * 0.01745329252f);
            yPow = Mathf.Sin(windDirection * 0.01745329252f);
            transform.eulerAngles = new Vector3(0, 0, windDirection);
            gDir.windchange = false;
        }
    }
}
