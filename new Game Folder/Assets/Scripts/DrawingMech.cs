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
    public Material wallMaterial;


    List<Vector3[]> startVertices = new List<Vector3[]>();

    List<GameObject> tunnel = new List<GameObject>();
    Vector3 normal;

    Mesh initialMesh;
    Vector2[] initialUV;


    List<int> indices = new List<int>();
	// Use this for initialization
    void Start()
    {
        wallMaterial = GetComponent<MeshRenderer>().material;
        initialMesh = createSquareMesh(width, height);
        initialMesh.RecalculateNormals();
        initialUV = CreateUVs().ToArray();
        for (int i = 0; i < 4; i++)
        {
            GameObject wall = new GameObject();
            if (i == 0)
            {
                wall.name = "baseWall";
                wall.tag = "Wall";
            }
            else 
            { 
                wall.name = "offWall";
                wall.tag = "Wall";
            }

            wall.AddComponent<MeshFilter>();
            wall.AddComponent<MeshRenderer>();
            Mesh mesh = new Mesh();
            mesh.vertices = initialMesh.vertices;
            mesh.triangles = initialMesh.triangles;
            normal = Vector3.Cross(mesh.vertices[0] - mesh.vertices[1], mesh.vertices[0] - mesh.vertices[width + 1]);
            mesh.vertices = VertexTranformer.ModelWall(mesh.vertices, topHeight, peakIntensity, normal);
            float random = Random.Range(spikeTop/4, spikeTop);
            mesh.vertices = VertexTranformer.CreateSpike(mesh.vertices, random, random - Random.Range(1, random - 1), height, width, Random.Range(0, peakCount));
            mesh = addFunnel(mesh.vertices, mesh.triangles, height, width);
            mesh.RecalculateNormals();
            mesh.uv = initialUV;
            wall.GetComponent<MeshRenderer>().material = wallMaterial;
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
	void Update ()
    {

	}


    List<Vector2> CreateUVs()
    {
        List<Vector2> UVs = new List<Vector2>();

        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
            {
                UVs.Add(new Vector2(x, y));
            }
        }
        for (int i = 0; i <= height; i++)
        {
            UVs.Add(new Vector2(-1, i));
        }
            return UVs;
 
    }

    public void ChangeMaterial(Material newMaterial)
    {
        wallMaterial = newMaterial;
    }

    public IEnumerator RecalculateVertices()
    {
        for (int i = 0; i < 4; i++)
        {
            Mesh mesh = new Mesh();
            mesh.vertices = initialMesh.vertices;
            mesh.triangles = initialMesh.triangles;
            yield return null;
            mesh.vertices = VertexTranformer.ModelWall(mesh.vertices, topHeight, peakIntensity, normal);
            float random = Random.Range(spikeTop / 4, spikeTop);
            yield return null;
            mesh.vertices = VertexTranformer.CreateSpike(mesh.vertices, random, random - Random.Range(1, random - 1), height, width, Random.Range(0, peakCount));
            yield return null;
            mesh = addFunnel(mesh.vertices, mesh.triangles, height, width);
            mesh.RecalculateNormals();
            mesh.uv = initialUV;
            tunnel[i].renderer.material = wallMaterial;
            tunnel[i].GetComponent<MeshFilter>().sharedMesh = mesh;
            tunnel[i].GetComponent<MeshCollider>().sharedMesh = mesh;
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

    Mesh addFunnel(Vector3[] vertices, int[] triangles, int height, int width)
    {
        Mesh mesh = new Mesh();
        int verticesLength = vertices.Length;
        List<int> triangleList = new List<int>(triangles);
        List<Vector3> vertexList = new List<Vector3>(vertices);

        for (int i = 0; i <= height; i++)
        {
            vertexList.Add(new Vector3(-1, i, 1));
        }
        for (int i = 0; i < height; i++)
        {
                triangleList.Add((width+1)*(i+1));
                triangleList.Add((width+1)*i);
                triangleList.Add(i + verticesLength);

                triangleList.Add(i + verticesLength);
                triangleList.Add(i + 1 + verticesLength);
                triangleList.Add((width + 1) * (i + 1));
          
        }
        mesh.vertices = vertexList.ToArray();
        mesh.triangles = triangleList.ToArray();

            return mesh;
 
    }
}
