using UnityEngine;
using System.Collections;

public class rotationCrazyPickup : PickupBase {

    public override void OnPickedUp()
    {

        PlayerControl.FlipRotation();

    }
}
