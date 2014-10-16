using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwarmBehaviour : MonoBehaviour
{
    /// <summary>
    /// the number of drones we want in this swarm
    /// </summary>
    [SerializeField]
    private int maxDrones;

    public float spawnRadius = 100f;
    public List<GameObject> drones;

    public Vector2 swarmBounds = new Vector2(300f, 300f);

    public GameObject prefab;

    // Use this for initialization
    protected virtual void Start()
    {
        if (prefab == null)
        {
            // end early
            Debug.Log("Please assign a drone prefab.");
            return;
        }

        // instantiate the drones
        
        drones = new List<GameObject>();
        
    }

    public void AddDrone()
    {
        AddDrones(1);
    }

    public void RemoveDrone()
    {
        RemoveDrones(1);
    }

    public void AddDrones(int amount)
    {
        GameObject droneTemp;
        if (drones.Count + amount > maxDrones)
            amount = maxDrones - drones.Count;

        for (int i = 0; i < amount; i++)
        {
            droneTemp = (GameObject)Instantiate(prefab, Vector3.zero, new Quaternion());
        
            DroneBehaviour db = droneTemp.GetComponent<DroneBehaviour>();
            db.drones = this.drones;
            db.swarm = this;

            // spawn inside circle
            Vector2 pos = new Vector2(transform.position.x, transform.position.z) + Random.insideUnitCircle * spawnRadius;
            droneTemp.transform.position = new Vector3(pos.x, transform.position.y, pos.y);
            droneTemp.transform.parent = transform;

            drones.Add(droneTemp);
        }
    }

    public void RemoveDrones(int amount)
    {
        List<GameObject> dronesToRemove = drones.GetRange(0, amount > drones.Count ? drones.Count : amount );
        foreach (GameObject drone in dronesToRemove)
        {
            drones.Remove(drone);
            Destroy(drone);
        }
    }

    

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(swarmBounds.x, 0f, swarmBounds.y));
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}