using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    public GameObject groundPrefab;

    [SerializeField]
    GameObject TestEnemy;
    [SerializeField]
    GameObject boidPickup;

    PickupSpawner pSpawner;
    public GameObject endScreen;
    public GameObject speedPowerUp;
    public GameObject crazyRotationPowerUp;

    void Awake()
    {
        pSpawner = new PickupSpawner(new Vector2(8f, 8f), new Vector2(-4, 1));
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myPos = transform.position;
		Vector3 playerPos = GameMaster.playerObject.transform.position;
		myPos.z = playerPos.z - 100;
		transform.position = myPos;
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag != "Drone")
        {

            if (other.name == "baseWall")
            {
                StartCoroutine(other.GetComponentInParent<DrawingMech>().RecalculateVertices());
                other.transform.position += new Vector3(0, 0, 180);
                //endScreen.transform.position += new Vector3(0, 0, 20);
                int speedPickupRng = Random.Range(0, 100);
                int crazyRotationPickupRng = Random.Range(0, 100);


                Instantiate(TestEnemy, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 180), new Quaternion());
                if (speedPickupRng < GameMaster.GetPowerUpValues().spawnSpeedChancePercent)
                {
                    Instantiate(speedPowerUp, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 180), new Quaternion());
                }
                if (crazyRotationPickupRng < GameMaster.GetPowerUpValues().spawnCrazyRotationChancePercent) {
                    Instantiate(crazyRotationPowerUp, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 180), new Quaternion());
                }

                
                Vector2 boidPos = pSpawner.GetNextBoidPosition();

                Instantiate(boidPickup, new Vector3(boidPos.x, boidPos.y, other.gameObject.transform.position.z + 100), new Quaternion());
            }
            else if (other.name == "offWall")
            {
                other.transform.position += new Vector3(0, 0, 180);
                endScreen.transform.position += new Vector3(0, 0, 20);
            }
        }
        else
        {
            Debug.Log("Hit drone");
        }


    }
}
