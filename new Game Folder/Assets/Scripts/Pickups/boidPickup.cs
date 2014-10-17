using UnityEngine;
using System.Collections;

public class boidPickup : PickupBase {

    public override void OnPickedUp()
    {
        PlayerControl.AddDrone();
    }
}
