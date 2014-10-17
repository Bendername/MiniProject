using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    public GameObject groundPrefab;

    [SerializeField]
    GameObject TestEnemy;
    [SerializeField]
    GameObject boidPickup;


    public GameObject endScreen;
    public GameObject speedPowerUp;
    public GameObject crazyRotationPowerUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Drone")
        {

            if (other.name == "grotto")
            {
                Debug.Log("Grotto hit! Current position: " + other.transform.position);
                other.transform.position += new Vector3(0, 0, 100);
                endScreen.transform.position += new Vector3(0, 0, 20);
                Debug.Log("New position: " + other.transform.position);
                int speedPickupRng = Random.Range(0, 100);
                int crazyRotationPickupRng = Random.Range(0, 100);
                
                Instantiate(TestEnemy, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
                if (speedPickupRng < GameMaster.GetPowerUpValues().spawnSpeedChancePercent)
                {
                    Instantiate(speedPowerUp, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
                }
                if (crazyRotationPickupRng < GameMaster.GetPowerUpValues().spawnCrazyRotationChancePercent) {
                    Instantiate(crazyRotationPowerUp, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
                }

                

                Instantiate(boidPickup, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
            }
        }
        else
        {
            Debug.Log("Hit drone");
        }


    }
}
