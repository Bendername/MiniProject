using UnityEngine;
using System.Collections;

public class boidPickup : PickupBase {

    public override void OnPickedUp()
    {
        UIScoring.ComboBoid();
        PlayerControl.AddDrone();

        GameObject[] g = GameObject.FindGameObjectsWithTag("Grotto");

        foreach (GameObject ga in g)
        {
            ga.GetComponent<CrazyTown>().ChangeMaterial();
        }
        
    }

    public override void OnNotPickupUp()
    {
        UIScoring.EndCombo();
    }
}
