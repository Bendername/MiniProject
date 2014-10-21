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
    public GameObject slingShotPowerUp;
    public GameObject thwomp;

    public Material[] materials;

    void Awake()
    {
        pSpawner = new PickupSpawner(new Vector2(-5, 2), new Vector2(9, 17));
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myPos = transform.position;
		Vector3 playerPos = GameMaster.playerObject.transform.position;
		myPos.z = playerPos.z - 30;
		transform.position = myPos;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Drone")
        {

            if (other.name == "baseWall")
            {
                StartCoroutine(other.GetComponentInParent<DrawingMech>().RecalculateVertices());
                other.transform.position += new Vector3(0, 0, 180);

                    other.GetComponent<MeshRenderer>().material = materials[1];
                
                //endScreen.transform.position += new Vector3(0, 0, 20);
                int speedPickupRng = Random.Range(0, 100);
                int slingShotPickupRng = Random.Range(0, 100);
                int thwompRng = Random.Range(0, 100);

				Instantiate(TestEnemy, pSpawner.GetRandomPosition(other.gameObject.transform.position.z + 180), Quaternion.Euler(new Vector3(0,180,0)));
                if (speedPickupRng < GameMaster.GetPowerUpValues().spawnSpeedChancePercent)
					Instantiate(speedPowerUp, pSpawner.GetRandomPosition(other.gameObject.transform.position.z + 180), new Quaternion());
                if (slingShotPickupRng < GameMaster.GetPowerUpValues().spawnCrazyRotationChancePercent)
					Instantiate(slingShotPowerUp, pSpawner.GetRandomPosition(other.gameObject.transform.position.z + 180), new Quaternion());
                if(thwompRng < GameMaster.EnemyValues().thwompChance)
					Instantiate(thwomp, pSpawner.GetRandomPosition(other.gameObject.transform.position.z + 180), new Quaternion());

                
                Vector2 boidPos = pSpawner.GetNextBoidPosition();

                Instantiate(boidPickup, new Vector3(boidPos.x, boidPos.y, other.gameObject.transform.position.z + 100), new Quaternion());
            }
            else if (other.name == "offWall")
            {
                other.transform.position += new Vector3(0, 0, 180);
                
            }
        }
        else
        {
            Debug.Log("Hit drone");
        }


    }
}
