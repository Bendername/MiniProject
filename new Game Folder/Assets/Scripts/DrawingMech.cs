using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawingMech : MonoBehaviour {

    RedPanda panda;

    Vector3[] vertices;
    List<int> indices = new List<int>();
	// Use this for initialization
	void Start () {
        panda = new RedPanda(1f);
        var mesh = createSquareMesh(20,10);
        mesh.RecalculateNormals();
        mesh.uv = new Vector2[mesh.vertexCount];
        GetComponent<MeshFilter>().mesh = mesh;
          Mesh e = this.GetComponent<MeshFilter>().mesh;
          vertices = e.vertices;
          for (int i = 0; i < vertices.Length; i++)
          {
              vertices[i] = new Vector3(vertices[i].x, vertices[i].y , vertices[i].z+ Random.Range(0f, 5f));
          }
          vertices[50] = new Vector3(vertices[50].x, vertices[50].y , vertices[50].z+10);
          vertices[49] = new Vector3(vertices[49].x, vertices[49].y, vertices[49].z+15);
          vertices[51] = new Vector3(vertices[51].x, vertices[51].y , vertices[51].z+7);
          e.vertices = vertices;
          e.RecalculateNormals();
    }

	// Update is called once per frame
	void Update () {



	}

    void AddSquare(Matrix4x4 matrix, float length, float width)
    {
/*float len = Mathf.Sqrt(length * length + Mathf.Sqrt(width - width));
        float a = length / len;
        float b = width / len;
        const int N = 5;
        for (int i = 0; i <= N; i++)
        {
            float alpha = 2.0f * Mathf.PI * i / (float)N;
            Vector3 p0 = matrix.MultiplyPoint(new Vector3(width * Mathf.Cos(alpha), width * Mathf.Sin(alpha), 0));
            Vector3 p1 = matrix.MultiplyPoint(new Vector3(width * Mathf.Cos(alpha), width * Mathf.Sin(alpha), length));

            alpha = 2.0f * Mathf.PI * (i + 1) / (float)N;
            Vector3 p2 = matrix.MultiplyPoint(new Vector3(width * Mathf.Cos(alpha), width * Mathf.Sin(alpha), 0));
            Vector3 p3 = matrix.MultiplyPoint(new Vector3(width * Mathf.Cos(alpha), width * Mathf.Sin(alpha), length));

           vertices.Add(p0);
            vertices.Add(p2);
            vertices.Add(p1);

            vertices.Add(p1);
            vertices.Add(p2);
            vertices.Add(p3);
            for (int j = 0; j < 6; j++)
            {
                indices.Add(indices.Count);
            }
        }*/
    }

 /*   public Mesh Interpret()
    {
        foreach (var elem in str)
        {
            switch (elem.symbol)
            {
                case LSElement.LSSymbol.DRAW:
                    AddCone(turtle.Peek().M, elem
                        .data[0], turtle.GetWidth(), turtle.GetWidth() * elem.data[1]);
                    turtle.Move(elem.data[0]);
                    break;
                case LSElement.LSSymbol.TURN:
                    turtle.Turn(elem.data[0]);
                    break;
                case LSElement.LSSymbol.ROLL:
                    turtle.Roll(elem.data[0]);
                    break;
                case LSElement.LSSymbol.LEFT_BRACKET:
                    turtle.Push();
                    break;
                case LSElement.LSSymbol.RIGHT_BRACKET:
                    turtle.Pop();
                    break;
                case LSElement.LSSymbol.WIDTH:
                    turtle.SetWidth(elem.data[0]);
                    break;
            }
        }

        AddSquare(panda.GetState().M, 3, 1);
        panda.Move(3);
        panda.TurnAroundY(50);
        AddSquare(panda.GetState().M, 3, 1);
        panda.Move(3);

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = indices.ToArray();
        vertices.Clear();
        indices.Clear();
        return mesh;
    }*/

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
        //Length*Height * 6
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
       foreach (int w in indices)
        {
            Debug.Log(w);
            Debug.Log(vertices[w]);
        }
        Debug.Log(indices.Count);
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
