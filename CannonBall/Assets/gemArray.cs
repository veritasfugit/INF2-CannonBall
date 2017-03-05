using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Experimentelles Script zur Kraftanzeige eines Schusses. Leider immer noch WIP
*/

public class gemArray : MonoBehaviour {

    private GameDirector gDir;
    private GameObject[] allGems;
    private GameObject gemPrefab;

	void Start () {
        allGems = new GameObject[10];
        gDir = GameObject.Find("SceneScripts").GetComponent<GameDirector>();
        gemPrefab = Resources.Load<GameObject>("gem");
        for (int i=0; i<10; i++)
        {
            allGems[i] = Instantiate(gemPrefab, transform.position, transform.rotation);
            allGems[i].transform.parent = transform;
            allGems[i].transform.localScale = new Vector3(1,1,1);
            allGems[i].transform.localPosition= new Vector3(i*0.7f, 0, 0);
        }

    }

    public void setGems(float pow)
    {
        for (int i=0; i<10; i++)
        {
            if (pow > 1 + 0.3 * i)
            {
                allGems[i].GetComponent<gemControl>().setCol(1);
            }
            else
            {
                allGems[i].GetComponent<gemControl>().setCol(3);
            }
        }
    }
	
	void Update () {
		
	}
}
