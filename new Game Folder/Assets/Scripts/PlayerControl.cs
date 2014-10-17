using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    static PlayerControl staticRef;
    private float rotationSpeed;
    private float movementSpeed;
    private float moveSpeedBonus = 0f;
    SwarmBehaviour swarm;
    AudioSource bgMusic;

    
    void Awake()
    {
        
        staticRef = this;
    }

	// Use this for initialization
	void Start () {
        rotationSpeed = GameMaster.GetPlayerValues().rotationSpeed;
        movementSpeed = GameMaster.GetPlayerValues().movementSpeed;
        swarm = GetComponentInChildren<SwarmBehaviour>();
        bgMusic = GetComponentInChildren<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
        rigidbody.velocity = transform.forward * (movementSpeed + moveSpeedBonus);
        //transform.position += transform.forward * Time.deltaTime * (movementSpeed + moveSpeedBonus);
	}

    public static void AddMoveSpeedBonus(float bonus)
    {
        staticRef.movementSpeed += bonus;
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
}
