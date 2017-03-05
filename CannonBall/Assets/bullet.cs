using UnityEngine;
using System.Collections;

/*
 * Script, dass das Verhalten des Geschosses lenkt
 * Methoden:
 * Start - referenzen setzung
 * Update - korrigiert die position der Kugel in relation zur Richtung in die sie sich bewegt und 
 * Zerstört sie selbstständig nach einiger Zeit wenn sie aus dem Level fliegt
 * OnCollisionEnter2D - Überprüft ob und was getroffen wird
 * DestroyThis - lässt den Sound erklingen, sagt dem GameDirector dass eine neue Runde starten sollte und Zerstört sich selbst
*/
public class bullet : MonoBehaviour {

    private GameDirector gDir;
    private float timer;
    private Rigidbody2D rb;
    private WindChanger wind;

    void Start()
    {
        gDir= GameObject.Find("SceneScripts").GetComponent<GameDirector>();
        timer = 3.0f;
        rb = GetComponent<Rigidbody2D>();
        wind = GameObject.Find("WindArrow").GetComponent<WindChanger>();
    }

    void Update()
    {
        rb.AddForce(new Vector2(wind.xPow,wind.yPow));
        transform.up = GetComponent<Rigidbody2D>().velocity;
        timer = timer-Time.deltaTime;
        if(timer <= 0)
        {
            DestroyThis();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //col.gameObject.GetComponent<PlayerHealth>().gotHit();
            gDir.hit = true;
            DestroyThis();
        }
        else
        {
            DestroyThis();
        }

    }
    void DestroyThis()
    {
        gDir.shotInAir = false;
        gDir.nextTurn();
        AudioSource sound = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(sound.clip, transform.position);
        Destroy(this.gameObject);
    }
}
