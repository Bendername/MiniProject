﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITitleScreen : MonoBehaviour {

    public Text highscore;

	// Use this for initialization
	void Start () {
        highscore.text = Mathf.Ceil(GameMaster.GetHighscore()).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
