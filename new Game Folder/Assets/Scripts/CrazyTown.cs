using UnityEngine;
using System.Collections;

public class CrazyTown : MonoBehaviour {

    public Material[] materials;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    public void ChangeMaterial()
    {
        foreach(Transform child in transform )
            child.gameObject.renderer.material = materials[Random.Range(0, 6)];
    }
}
