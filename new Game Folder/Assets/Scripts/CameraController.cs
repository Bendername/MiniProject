using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject player;

    public float camChaseDistance = 50;

    [SerializeField]
    private Vector2 maxPosition = new Vector2(4f, 4f);
    [SerializeField]
    private Vector2 offset = new Vector2(-2f, -2f);


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 myPos = transform.position;
        Vector3 playerPos = player.transform.position;

        float xPercent = (playerPos.x + 5) / 10;
        float yPercent = playerPos.y / 10;

        transform.position = new Vector3(Mathf.Lerp(0f, maxPosition.x, xPercent) + offset.x, Mathf.Lerp(0f, maxPosition.y, yPercent) + offset.y, playerPos.z - camChaseDistance);
        transform.LookAt(playerPos);
        
	}
}
