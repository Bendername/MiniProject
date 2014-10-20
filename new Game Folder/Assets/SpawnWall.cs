using UnityEngine;
using System.Collections;

public class SpawnWall : MonoBehaviour {
    public GameObject walls;
	// Use this for initialization
    GameObject test;
    GameObject test1;
    GameObject test2;
    GameObject test3;

	void Start () {

        test = new GameObject();


        test1 = new GameObject(); 
        test2 = new GameObject(); 
        test3 = new GameObject(); 

        GameObject w = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        w.transform.parent = test.transform;

        GameObject a = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        a.transform.parent = test1.transform;

        GameObject b = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        b.transform.parent = test2.transform;

        GameObject c = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        c.transform.parent = test3.transform;


      //  GameObject a = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
       // GameObject b = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
       // GameObject c = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());

	}

    int i = 0;
	// Update is called once per frame
	void Update () {
        if(i == 0)
        {
            test.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 0);
            test1.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 18);
            test2.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 36);
            test3.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 52);
        i++;
        }
	}
}
