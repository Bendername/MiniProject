using UnityEngine;
using System.Collections;

public class speedPickup : PickupBase {

    public override void OnPickedUp()
    {

        PlayerControl.AddMoveSpeedBonus(10);

    }
}
