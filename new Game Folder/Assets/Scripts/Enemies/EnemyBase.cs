﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class EnemyBase : MonoBehaviour {

    [SerializeField]
    GameObject DeathGUI;

    void Awake()
    {
        collider.isTrigger = true;
    }

    void OnTriggerEnter(Collider hitBy)
    {
        if (hitBy.GetComponent<PlayerControl>())
        {
            //player bumped into me, player dies
            Instantiate(DeathGUI);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
