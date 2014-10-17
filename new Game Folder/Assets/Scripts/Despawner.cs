﻿using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    public GameObject groundPrefab;

    [SerializeField]
    GameObject TestEnemy;

    public GameObject powerUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Drone")
        {
            other.transform.position += new Vector3(0, 0, 100);

            if (other.name == "grotto")
            {
                Instantiate(TestEnemy, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
                int rng = Random.Range(0, 100);
                Debug.Log(rng);
                if (rng < GameMaster.GetPowerUpValues().spawnChancePercent)
                {
                    Instantiate(powerUp, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
                }
            }
        }
        else
        {
            Debug.Log("Hit drone");
        }


    }
}
