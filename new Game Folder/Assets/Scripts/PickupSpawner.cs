using UnityEngine;
using System.Collections;

public class PickupSpawner {

    
    Vector2 lastPosition;
    Vector2 maxCoords;
    Vector2 offset;
    
	public PickupSpawner(Vector2 size, Vector2 offset)
    {
        maxCoords = size;
        this.offset = offset;
    }

    public Vector2 GetNextBoidPosition()
    {
        if (lastPosition == null)
        {
            lastPosition = new Vector2(Random.Range(0f, maxCoords.x), Random.Range(0f, maxCoords.y));
        }
        else
        {
            lastPosition.x += Random.Range(-1f, 1f);
            lastPosition.y += Random.Range(-1f, 1f);

            if (lastPosition.x > maxCoords.x)
                lastPosition.x = maxCoords.x;
            else if (lastPosition.x < 0)
                lastPosition.x = 0;


            if (lastPosition.y > maxCoords.y)
                lastPosition.y = maxCoords.y;
            else if (lastPosition.y < 0)
                lastPosition.y = 0;
        }

        return lastPosition + offset;
    }

    
}
