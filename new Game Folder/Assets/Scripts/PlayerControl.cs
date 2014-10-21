using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    static PlayerControl staticRef;
    private float rotationSpeed;
    private float movementSpeed = 25f;
    private float moveSpeedBonus = 0f;
    private bool rotationIdle = true;
    private float crazyRotationSpeed = 10f;
    SwarmBehaviour swarm;
    AudioSource bgMusic;

    
    void Awake()
    {
        
        staticRef = this;
    }

	// Use this for initialization
	void Start () {
        if (GameMaster.GetGameValues().isTitleScreen)
        {
            collider.isTrigger = true;
            audio.Stop();
        }

        rotationSpeed = GameMaster.GetPlayerValues().rotationSpeed;
        movementSpeed = GameMaster.GetPlayerValues().movementSpeed;
        swarm = GetComponentInChildren<SwarmBehaviour>();
        bgMusic = GetComponentInChildren<AudioSource>();
		GameMaster.playerObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Transform t = transform;
		Vector3 rotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse X")) * rotationSpeed * Time.deltaTime;
        
        if(GameMaster.GetGameValues().isTitleScreen)
        {
            rigidbody.velocity = transform.forward * (movementSpeed + moveSpeedBonus) / 20;
        }
        else
        {
            t.Rotate(rotation);
            rigidbody.velocity = transform.forward * (movementSpeed + moveSpeedBonus);
        }
        

	}

    public static void FlipRotation()
    {
        float newSpeed = (Random.Range(0, 10) > 7) ? Random.Range(-250f, 250f) : Random.Range(-50f, 50f);
        
        Debug.Log(newSpeed);
        staticRef.crazyRotationSpeed = newSpeed;
    }

    public static void AddMoveSpeedBonus(float bonus)
    {
        staticRef.movementSpeed += bonus;
		staticRef.bgMusic.pitch = 1 + staticRef.movementSpeed / 200;
    }

    public static float GetMovementSpeed()
    {
        return staticRef.movementSpeed;
    }

    public static void AddDrone()
    {
        staticRef.swarm.AddDrone();
    }

    public static void RemoveDrone()
    {
        staticRef.swarm.RemoveDrone();
    }

    public static AudioSource GetBgMusic()
    {
        return staticRef.bgMusic;
    }

    public static int DroneCount()
    {
        return staticRef.swarm.drones.Count;
    }
    public static float GetDistance()
    {
        //Player is not actually at 0 at the beginning, so don't count before he's past it.
        return (staticRef.transform.position.z > 0) ? staticRef.transform.position.z : 0 ;
    }
}
