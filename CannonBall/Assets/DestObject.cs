using UnityEngine;
using System.Collections;

/*
 * Einfaches Script um ein Umgebungsobjekt Zerstörbar zu machen 
*/
public class DestObject : MonoBehaviour {

    public int dur = 3;

	void Start () {
    
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullet")
        {
            if(dur <= 1)
            {
                Destroy(gameObject);
            }else
            {
                dur -= 1;
            }
        }
    }


}
