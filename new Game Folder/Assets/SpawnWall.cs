using UnityEngine;
using System.Collections;

public class SpawnWall : MonoBehaviour {
    public GameObject walls;
	// Use this for initialization
    GameObject test;
    GameObject test1;
    GameObject test2;
    GameObject test3;
    GameObject test4;

	void Start () {
        //TODO: REFACTOR!

        test = new GameObject();
        test1 = new GameObject(); 
        test2 = new GameObject();
        test3 = new GameObject();
        test4 = new GameObject(); 

        GameObject w = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        w.transform.parent = test.transform;
        test.name = "wall";

        GameObject a = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        a.transform.parent = test1.transform;
        test1.name = "wall";

        GameObject b = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        b.transform.parent = test2.transform;
        test2.name = "wall";

        GameObject c = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        c.transform.parent = test3.transform;
        test3.name = "wall";

        GameObject d = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
        d.transform.parent = test4.transform;
        test4.name = "wall";

	}

    int i = 0;
	// Update is called once per frame
	void Update () {
        if(i == 0)
        {
            test.transform.localPosition = test.transform.localPosition + new Vector3(-6.5f, 0, -11f);
            test1.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 18);
            test2.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 36);
            test3.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 52);
            test4.transform.localPosition = test.transform.localPosition + new Vector3(0, 0, 70);
        i++;
        }
	}
}
