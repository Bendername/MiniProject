using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScoring : MonoBehaviour {

    public Text score;
    public Text boids;

	// Use this for initialization
	void Start () {
        score.text = "0";
        boids.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        boids.text = PlayerControl.DroneCount().ToString();
        score.text = ((PlayerControl.GetDistance() * GameMaster.GetScoringValues().scoreToTime) + (PlayerControl.DroneCount() * GameMaster.GetScoringValues().scorePerBoid)).ToString();
	}
}
