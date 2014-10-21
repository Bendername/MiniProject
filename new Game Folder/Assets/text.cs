using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class text : MonoBehaviour {


	public GameObject highscoreText;


	public GameObject scoreText;

	// Use this for initialization
	void Start () {
        scoreText.GetComponent<Text>().text = GameMaster.GetScore().ToString("0.00");
		float score = GameMaster.GetScore ();
		if (score > GameMaster.GetHighscore())
						PlayerPrefs.SetFloat ("Highscore", score);

		highscoreText.GetComponent<Text> ().text = GameMaster.GetHighscore ().ToString("0.00");
	}
	
	
}
