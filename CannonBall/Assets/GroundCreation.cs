using UnityEngine;
using System.Collections;

/*
 *Experimentelles erstes Script zur erstellung eines zufälligen Levels. - Obsolet 
 * 
*/
public class GroundCreation : MonoBehaviour {

    private int[,] spielfeld = new int[20,10];
    private GameObject[] blocks = new GameObject[200];
    private Random rnd = new Random();
    public GameObject block1;

	void Start () {
        block1 = Resources.Load<GameObject>("EarthCube");
        print(blocks);
	    for(int i = 1; i < 20; i++)
        {
            for (int q = 1; q < 10; q++)
            {
                print("i =" + i + "q =" + q);
                if (spielfeld[i,q] == 0 && spielfeld[i,q-1] == 1 && Random.Range(0.0f,15.0f) > q || q == 1)
                {
                    blocks[i*10 + q] = Instantiate(block1,transform.position,transform.rotation) as GameObject;
                    blocks[i*10 + q].transform.Translate(i, q, 0);
                    spielfeld[i,q] = 1;
                }
            }
        }
	}
	
	void Update () {
	
	}
}
