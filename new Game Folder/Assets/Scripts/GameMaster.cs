using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {


    public Player player;
    public PowerUps powerUps;
    public Scoring scoring;
    public Enemies enemies;
    static GameMaster gameMasterRef;
	public static GameObject playerObject;

    public void Awake(){
        gameMasterRef = this;

        Screen.showCursor = false;
    }

    [System.Serializable]
    public class Player
    {
        public float movementSpeed = 10f;
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
        return gameMasterRef.player;
    }

    public static Scoring GetScoringValues()
    {
        return gameMasterRef.scoring;
    }




}
