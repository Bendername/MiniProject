using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshRemodeling : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Change_Mesh();
	}
	
	// Update is called once per frame
    void Update()
    {



    }
    Vector3[] vertices;
    void Change_Mesh()
    {
        Mesh w = this.GetComponent<MeshFilter>().mesh;
        vertices = w.vertices;
        for (int i= 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices[i].x, vertices[i].y + Random.Range(0f, 5f), vertices[i].z);
        }
        vertices[50] = new Vector3(vertices[50].x, vertices[50].y + 10, vertices[50].z);
        vertices[49] = new Vector3(vertices[49].x, vertices[49].y + 7, vertices[49].z);
        vertices[51] = new Vector3(vertices[51].x, vertices[51].y + 15, vertices[51].z);
        w.vertices = vertices;
        w.RecalculateNormals();
    }
}
