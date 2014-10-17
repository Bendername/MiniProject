using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScoring : MonoBehaviour {

    static UIScoring staticRef;

    public Text scoreText;
    public Text boidsText;
    public Text comboText;

    GameMaster.Scoring scoreValues;

    float score = 0;

    float comboMultiplier = 1f;
    float speedMultiplier = 1f;

    void Awake()
    {
        staticRef = this;
    }

	// Use this for initialization
	void Start () {
        scoreText.text = "0";
        boidsText.text = "0";
        scoreValues = GameMaster.GetScoringValues();
	}
	
	// Update is called once per frame
	void Update () {
        score += scoreValues.scoreToTime * Time.deltaTime * speedMultiplier * comboMultiplier;
        boidsText.text = PlayerControl.DroneCount().ToString();
        scoreText.text = score.ToString("0");
        comboText.text = "x" + comboMultiplier.ToString("0.0");
	}

    public static void EndCombo()
    {
        staticRef.comboMultiplier = 1f;
    }

    public static void ComboBoid()
    {
        staticRef.comboMultiplier += GameMaster.GetScoringValues().BoidComboMultiplier;
        staticRef.score += staticRef.scoreValues.scorePerBoid * staticRef.comboMultiplier * staticRef.speedMultiplier;
    }

    public static void IncreaseSpeedMultiplier()
    {
        staticRef.speedMultiplier += GameMaster.GetScoringValues().SpeedMultiplier;
    }
}
