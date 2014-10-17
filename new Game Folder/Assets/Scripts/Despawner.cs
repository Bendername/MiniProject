using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    public GameObject groundPrefab;
    [Tooltip("Spawn chance in %")]
    public float spawnchance = 10;

    [SerializeField]
    GameObject TestEnemy;
    [SerializeField]
    GameObject boidPickup;

    public GameObject powerUp;
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
                Debug.Log("New position: " + other.transform.position);
                Instantiate(TestEnemy, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
                int rng = Random.Range(0, 100);

                if (rng < spawnchance)
                {
                    Instantiate(powerUp, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 100), new Quaternion());
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
