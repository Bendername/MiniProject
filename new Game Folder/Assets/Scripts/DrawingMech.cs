using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawingMech : MonoBehaviour {

    Vector3[] vertices;

    public float topHeight = 1;
    public float peakIntensity = 0.1f;
    public float peakFrequency = 5;
    public float spikeTop = 1;
    public float spikeIntensity = 1;
    public int peakCount;
    public int height;
    public int width;


    List<Vector3[]> startVertices = new List<Vector3[]>();

    List<GameObject> tunnel = new List<GameObject>();
    Vector3 normal;

    List<int> indices = new List<int>();
	// Use this for initialization
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject wall = new GameObject();
            if (i == 0)
            {
                wall.name = "baseWall";
            }
            else { wall.name = "offWall"; }

            wall.AddComponent<MeshFilter>();
            wall.AddComponent<MeshRenderer>();
            Mesh mesh;
            mesh = createSquareMesh(width, height);
            mesh.RecalculateNormals();
            mesh.uv = new Vector2[mesh.vertexCount];
            normal = Vector3.Cross(mesh.vertices[0] - mesh.vertices[1], mesh.vertices[0] - mesh.vertices[width + 1]);
        //    startVertices.Add(placeHolder);
            mesh.vertices = VertexTranformer.ModelWall(mesh.vertices, topHeight, peakIntensity, normal);
            float random = Random.Range(3f, 10f);

            mesh.vertices = VertexTranformer.CreateSpike(mesh.vertices, random, random - Random.Range(1, random - 1), height, width, Random.Range(0, 2));
            mesh.RecalculateNormals();
            wall.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
            wall.GetComponent<MeshFilter>().mesh = mesh;
            wall.transform.Rotate(new Vector3(90 * i, 0, 0));
            wall.AddComponent<MeshCollider>();
            tunnel.Add(wall);
            wall.transform.parent = transform;
        }
        tunnel[3].transform.position = tunnel[0].transform.position + new Vector3(0, 18.3f, 1.75f);
        tunnel[2].transform.position = tunnel[0].transform.position + new Vector3(0, 20f, -16.585f);
        tunnel[1].transform.position = tunnel[0].transform.position + new Vector3(0, 1.5f, -18.5f);
        transform.Rotate(new Vector3(0, -90, 0));

    }

	// Update is called once per frame
	void Update () {

	}

    public void RecalculateVertices()
    {
        for (int i = 0; i < 4; i++)
        {
            Mesh mesh;
            mesh = createSquareMesh(width, height);
            mesh.RecalculateNormals();
            mesh.vertices = VertexTranformer.ModelWall(mesh.vertices, topHeight, peakIntensity, normal);
            float random = Random.Range(3f, 10f);

mesh.vertices = VertexTranformer.CreateSpike(mesh.vertices, random, random - Random.Range(1, random - 1), height, width, Random.Range(0, 2));
            mesh.RecalculateNormals();
            tunnel[i].GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
            tunnel[i].GetComponent<MeshFilter>().mesh = mesh;
            Destroy(tunnel[i].GetComponent<MeshCollider>());
            tunnel[i].AddComponent<MeshCollider>();
        }
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

        return mesh;
    }
}
