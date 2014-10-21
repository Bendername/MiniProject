using UnityEngine;
using System.Collections;

public class slingShotPowerUp : PickupBase {

    public GameObject prefab;

    public override void OnPickedUp()
    {

        Instantiate(prefab);

    }
}
