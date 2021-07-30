using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Vector3 ReturnEndPoint()
    {

        Vector3 calculatedEndPoint; 
        calculatedEndPoint.x = SpriteRenderer.bounds.size.x + this.transform.position.x 
            + Random.Range(0f,3f);
        calculatedEndPoint.y = Random.Range(0f,3f);
        calculatedEndPoint.z = 0;



        return calculatedEndPoint;
    }
}
