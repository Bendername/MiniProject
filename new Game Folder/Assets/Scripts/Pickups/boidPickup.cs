using UnityEngine;
using System.Collections;

public class boidPickup : PickupBase {

    public override void OnPickedUp()
    {
        PlayerControl.AddDrone();

        GameObject[] g = GameObject.FindGameObjectsWithTag("Grotto");


        foreach (GameObject ga in g)
        {
            ga.GetComponent<CrazyTown>().ChangeMaterial();
        }
        
    }
}
