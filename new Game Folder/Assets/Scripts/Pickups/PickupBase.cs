using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PickupBase : MonoBehaviour
{
    [SerializeField]
    GameObject pickupSound;

    bool playSound = true;
    bool rotateIdle = true;
    float rotateIdleSpeed = 50f;

    void Awake()
    {
        collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateIdle)
            transform.Rotate(new Vector3(0, Time.smoothDeltaTime * rotateIdleSpeed, 0));
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
    }

    public virtual void OnPickedUp()
    {

    }
}
