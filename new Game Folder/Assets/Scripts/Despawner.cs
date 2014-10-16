using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    public GameObject groundPrefab;

    [SerializeField]
    GameObject TestEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BOOM!");

        if (other.gameObject.tag != "Drone")
        {
            Instantiate(groundPrefab, new Vector3(0, 0, other.gameObject.transform.position.z + 60), new Quaternion());
            Instantiate(TestEnemy, new Vector3(Random.Range(-4, 5), Random.Range(1, 10), other.gameObject.transform.position.z + 60), new Quaternion());

            Debug.Log("After instantiate");
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Hit drone");
        }
    }
}
