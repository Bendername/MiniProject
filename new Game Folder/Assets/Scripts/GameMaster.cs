using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {


    public Game game;
    public Player player;
    public PowerUps powerUps;
    public Scoring scoring;
    public Enemies enemies;
    public float Score;
    static GameMaster gameMasterRef;
	public static GameObject playerObject;

    public void Awake(){
        gameMasterRef = this;
    }

    public void Start()
    {
        if (!this.game.isTitleScreen)
            Screen.showCursor = false;
        else
            Screen.showCursor = true;
    }

    [System.Serializable]
    public class Game
    {
        public bool isTitleScreen = false;
    }

    [System.Serializable]
    public class Player
    {
        public float movementSpeed = 10f;
        public float movementSpeedMultiplier = 1f;
        public float rotationSpeed = 50f;
    }

    [System.Serializable]
    public class PowerUps
    {
        public int spawnSpeedChancePercent          = 15;
        public int spawnCrazyRotationChancePercent  = 10;
        public float speedBuffModifier              = 5;
        public float experienceBonusModifier        = 10;
    }

    [System.Serializable]
    public class Scoring
    {
        public float scoreToTime = 0.1f;
        public float scorePerBoid = 5;
        public float BoidComboMultiplier = 0.1f;
        public float SpeedMultiplier = 0.1f;
    }

    [System.Serializable]
    public class Enemies
    {
        public float thwompChance = 10f;
    }

    public static Enemies EnemyValues(){
        return gameMasterRef.enemies;
    }

    public static PowerUps GetPowerUpValues()
    {
        return gameMasterRef.powerUps;
    }

    public static Player GetPlayerValues()
    {
        gameMasterRef.player.movementSpeed = PlayerControl.GetMovementSpeed();
        return gameMasterRef.player;
    }

    public static Scoring GetScoringValues()
    {
        return gameMasterRef.scoring;
    }
    public static Game GetGameValues()
    {
        return gameMasterRef.game;
    }

    public static void SetScore(float score)
    {
        gameMasterRef.Score = score;
    }

    public static float GetScore()
    {
        return gameMasterRef.Score;
    }

	public static float GetHighscore()
	{
		return PlayerPrefs.GetFloat("Highscore");
	}


}
