using UnityEngine;
using System.Collections;

public class speedPickup : PickupBase {

    public override void OnPickedUp()
    {

        PlayerControl.AddMoveSpeedBonus(GameMaster.GetPowerUpValues().speedBuffModifier);
        PlayerControl.GetBgMusic().pitch += 0.05f;
        UIScoring.IncreaseSpeedMultiplier();
    }
}
