using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public Player player;
    public PowerUps powerUps;
    public Scoring scoring;
    static GameMaster gameMasterRef;

    public void Awake(){
        gameMasterRef = this;
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
        public int spawnChancePercent            = 10;
        public float speedBuffModifier          = 5;
        public float experienceBonusModifier    = 10;
    }

    [System.Serializable]
    public class Scoring
    {
        public float scoreToTime = 0.1f;
        public float scorePerBoid = 5;
        public float BoidComboMultiplier = 0.1f;
        public float SpeedMultiplier = 0.1f;
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
