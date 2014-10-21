using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PickupBase : MonoBehaviour
{
    [SerializeField]
    GameObject pickupSound;

	[SerializeField]
	float FadeDistance;

	bool fadeOut = true;
    bool playSound = true;
    bool rotateIdle = true;
    float rotateIdleSpeed = 50f;

	Material mat;

    void Awake()
    {
        collider.isTrigger = true;
    }

	void Start()
	{
		mat = renderer.material;
	}


    // Update is called once per frame
    void Update()
    {
        if (rotateIdle)
            transform.Rotate(new Vector3(0, Time.smoothDeltaTime * rotateIdleSpeed, 0));


		if (fadeOut) {
			Color clr = mat.color;
			clr.a = Vector3.Distance(GameMaster.playerObject.transform.position,transform.position) / FadeDistance;
			mat.color = clr;
		}

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControl>()) //evaluates to true if it collides with something with player controls
        {
            //if instructed to play sound, and there exists a sound, play it
            if (playSound && pickupSound)
                Instantiate(pickupSound);

            OnPickedUp();
            Destroy(gameObject);
        }
        else if (other.tag == "Despawner")
        {
            OnNotPickupUp();
            Destroy(gameObject);
        }
    }

    public virtual void OnPickedUp()
    {

    }

    public virtual void OnNotPickupUp()
    {

    }
}
