using UnityEngine;
using System.Collections;

public class speedPickup : PickupBase {

    public override void OnPickedUp()
    {

       GameObject.Find("Player").GetComponent<PlayerControl>().movementSpeed *= 5;

    }
}
