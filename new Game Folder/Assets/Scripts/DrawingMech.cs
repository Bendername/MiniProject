﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawingMech : MonoBehaviour {

    Vector3[] vertices;

    public float topHeight = 1;
    public float peakIntensity = 0.1f;
    public float peakFrequency = 5;
    public int height;
    public int width;
    Mesh mesh;

    List<int> indices = new List<int>();
	// Use this for initialization
	void Start () {
        mesh = createSquareMesh(width, height);
        mesh.RecalculateNormals();
        mesh.uv = new Vector2[mesh.vertexCount];
        Vector3 normal = Vector3.Cross(mesh.vertices[0]- mesh.vertices[1] , mesh.vertices[0] -mesh.vertices[width + 1] );
         mesh.vertices =VertexTranformer.test(mesh.vertices, topHeight, peakIntensity, peakFrequency, normal);
         mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        
    }

	// Update is called once per frame
	void Update () {
	}

    List<Vector3> CreateVertices(int length, int height)
    {
        List<Vector3> collection = new List<Vector3>();
        for (int y = 0; y < height+1; y++)
        {
            for (int x = 0; x < length+1; x++)
            {
                Vector3 p1 = new Vector3(x, y);
                collection.Add(p1);

            }
        }
        return (collection);
 
    }
    List<int> CreateTriangles(List<Vector3> vertices, int length, int height)
    {
        List<int> indices = new List<int>();
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < height; y++)
            {
                indices.Add(x + (y*length + y));
                indices.Add(length + x + 1 + (y*length+y));
                indices.Add(x + 1 + (y*length+y));

                indices.Add(x + length + 1 + (y*length+y));
                indices.Add(2 + length + x + (y*length+y));
                indices.Add(x + 1+ (y*length+y));
               
            }
        }
          return (indices);
    }


    Mesh createSquareMesh(int length, int height)
    {
        List<Vector3> vertexCollection= CreateVertices(length, height);
        List<int> indicesCollection = CreateTriangles(vertexCollection,length, height);

        
        Mesh mesh = new Mesh();
        mesh.vertices = vertexCollection.ToArray();
        mesh.triangles = indicesCollection.ToArray();

        //vertices.Clear();
       // indices.Clear();
        return mesh;
    }
}
