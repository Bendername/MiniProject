using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PickupBase : MonoBehaviour
{

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
            OnPickedUp();
            Destroy(gameObject);
        }
    }

    public virtual void OnPickedUp()
    {

    }
}
