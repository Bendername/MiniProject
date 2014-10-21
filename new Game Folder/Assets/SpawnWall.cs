using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnWall : MonoBehaviour {
    public GameObject walls;
    public int numberOfWalls = 1;
	// Use this for initialization
    List<GameObject> wallList = new List<GameObject>();


	void Start () {

        for (int i = 0; i < numberOfWalls; i++)
        {
            GameObject tunnel = new GameObject();
            GameObject prefab = (GameObject)Instantiate(walls, Vector3.zero, new Quaternion());
            prefab.transform.parent = tunnel.transform;
            tunnel.name = "wall";
            wallList.Add(tunnel);

        }

	}

    int i = 0;
	// Update is called once per frame
	void LateUpdate () {
        if(i == 0)
        {
            for (int k = 0; k < wallList.Count; k++)
            {
                if(k ==0)
                {
                wallList[k].transform.localPosition = wallList[k].transform.localPosition + new Vector3(-6.5f, 0, -11f);
                }
                else
                {
                    wallList[k].transform.localPosition = wallList[k].transform.localPosition + new Vector3(-6.5f, 0, -11f +k * 18);
                }
            }
        i++;
        }
	}
}
