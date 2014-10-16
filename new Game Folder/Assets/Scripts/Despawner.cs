using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    public GameObject groundPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BOOM!");

        
        Instantiate(groundPrefab, new Vector3(0,0,other.gameObject.transform.position.z + 60), new Quaternion());
        Debug.Log("After instantiate");
        Destroy(other.gameObject);
    }
}
