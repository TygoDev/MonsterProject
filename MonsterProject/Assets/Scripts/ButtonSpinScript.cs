using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpinScript : MonoBehaviour
{
    public RotatingObstacle parentObject;

    public List<RotatingObstacle> childrenThatRotate = new List<RotatingObstacle>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Player))
        {
            parentObject.stop = false;

            foreach(var child in childrenThatRotate)
            {
                child.stop = true;
                child.gameObject.transform.rotation = Quaternion.identity;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(Tags.T_Player))
        {
            parentObject.stop = true;

            foreach (var child in childrenThatRotate)
            {
                child.stop = false;
            }
        }
    }
}
