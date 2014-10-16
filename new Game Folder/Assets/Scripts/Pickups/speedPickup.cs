using UnityEngine;
using System.Collections;

public class speedPickup : PickupBase {

    public GameObject player;

    public override void OnPickedUp()
    {

        player.GetComponent<PlayerControl>().movementSpeed *= 5;

    }
}
