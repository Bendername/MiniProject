using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private float rotationSpeed = 50f;
    private float movementSpeed = 5f;

    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
	}
}
