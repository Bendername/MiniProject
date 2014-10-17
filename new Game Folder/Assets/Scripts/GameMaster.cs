using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public Player player;
    public PowerUps powerUps;
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

    public static PowerUps GetPowerUpValues()
    {
        return gameMasterRef.powerUps;
    }

    public static Player GetPlayerValues()
    {
        return gameMasterRef.player;
    }


}
