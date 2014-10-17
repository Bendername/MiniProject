using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    [SerializeField]
    float DestroyTimer;
	
	// Update is called once per frame
	void Update () {
        DestroyTimer -= Time.deltaTime;
        if (DestroyTimer <= 0)
            Destroy(gameObject);
	}
}
