using UnityEngine;
using System.Collections;

public class PickupSpawner {

    
    Vector2 lastPosition;
    Vector2 min;
    Vector2 max;
    
	public PickupSpawner(Vector2 min, Vector2 max)
    {
        this.min = min;
        this.max = max;
    }

    public Vector2 GetNextBoidPosition()
    {
        if (lastPosition == null)
        {
            lastPosition = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        }
        else
        {
            lastPosition.x += Random.Range(-1f, 1f);
            lastPosition.y += Random.Range(-1f, 1f);

            if (lastPosition.x > max.x)
                lastPosition.x = max.x;
            else if (lastPosition.x < min.x)
                lastPosition.x = min.x;


            if (lastPosition.y > max.y)
                lastPosition.y = max.y;
            else if (lastPosition.y < min.y)
                lastPosition.y = min.y;
        }

        return lastPosition;
    }

    
}
