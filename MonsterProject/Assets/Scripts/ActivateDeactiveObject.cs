using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactiveObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToChange;
    [SerializeField] private List<GameObject> ObjectsToChange = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToChange.SetActive(boolToggle(objectToChange.activeInHierarchy));
            if(ObjectsToChange.Count > 0)
            {
                foreach (GameObject obj in ObjectsToChange)
                {
                    obj.SetActive(boolToggle(obj.activeInHierarchy));
                }
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToChange.SetActive(objectToChange.activeInHierarchy);
            if (ObjectsToChange.Count > 0)
            {
                foreach (GameObject obj in ObjectsToChange)
                {
                    obj.SetActive(boolToggle(boolToggle(obj.activeInHierarchy)));
                }
            }
        }
    }

    bool boolToggle(bool boolean)
    {
        bool booleanVar = boolean;
        return booleanVar = booleanVar ? false : true;
    }
}
