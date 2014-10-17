using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class VertexTranformer{

    public static Vector3[] ModelWall(Vector3[] vertices, float topHeight, float peakIntensity, Vector3 normal)
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
    
    public static Vector3[] CreateSpike(Vector3[] vertices, float topHeight, float peakIntensity, int height, int width, int numberOfPeaks)
    {
        int rangeFromCenter = (int)(topHeight / peakIntensity);
        Debug.Log(rangeFromCenter);

        for (int i = 0; i < numberOfPeaks; i++)
        {
            int xCenter = Random.Range(rangeFromCenter, width - rangeFromCenter);
            int yCenter = Random.Range(rangeFromCenter, height - rangeFromCenter);

            for (int y = yCenter - rangeFromCenter; y < yCenter + rangeFromCenter; y++)
            {
                for (int x = xCenter - rangeFromCenter; x < xCenter + rangeFromCenter; x++)
                {
                    float DistanceFromCenter = Vector2.Distance(new Vector2(xCenter, yCenter), new Vector2(x, y));
                    if (DistanceFromCenter > rangeFromCenter)
                    {
                        DistanceFromCenter = rangeFromCenter;
                    }
                    else if (DistanceFromCenter != 0)
                    {
                        vertices[y * (width + 1) + x] = vertices[y * (width + 1) + x] + new Vector3(0,0,-Random.Range(rangeFromCenter - DistanceFromCenter, topHeight / DistanceFromCenter));
                    }
                }
            }
            vertices[yCenter * (width + 1) + xCenter] = vertices[yCenter * (width + 1) + xCenter] + new Vector3(0, 0, -topHeight);

        }

        return vertices;
    }
}
