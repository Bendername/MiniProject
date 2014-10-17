using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class VertexTranformer{

    public static Vector3[] test(Vector3[] vertices, float topHeight, float peakIntensity, float peakFrequency, Vector3 normal)
    {
        Vector3 lastVertex = vertices[0];
        float lastMagnitude = 0;
        bool tophightIsReached = false;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 hight = vertices[i] +  normal * (lastMagnitude +Random.Range(-peakIntensity, peakIntensity));

            if(tophightIsReached == true)
            {
                hight = vertices[i] + normal * Random.Range(-peakIntensity, 0);
                tophightIsReached = false;
            }
            else if (Mathf.Abs(((Vector3)(vertices[i] - hight)).magnitude) >= topHeight) //See if 
            {
                hight = vertices[i] + normal * topHeight;
                tophightIsReached = true;
            }
            else if (Mathf.Abs(((Vector3)(hight - lastVertex)).magnitude) < 0)
            {
                hight = vertices[i];
            }
            lastMagnitude = Mathf.Abs(((Vector3)(vertices[i] - hight)).magnitude);
            vertices[i] = hight;
            lastVertex = vertices[i];
        }

        return vertices;
    }
}
