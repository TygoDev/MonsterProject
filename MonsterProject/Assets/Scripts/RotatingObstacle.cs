using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float speed;

    public enum rotationAxis { 
        X,
        Y,
        Z
    }

    public rotationAxis axis = rotationAxis.Z;
    void Update()
    {
        if(axis == rotationAxis.Z)
            this.transform.Rotate(0, 0, speed);
        
        if(axis == rotationAxis.Y)
            this.transform.Rotate(0, speed, 0);
        
        if(axis == rotationAxis.X)
            this.transform.Rotate(speed, 0, 0);
    }
}
