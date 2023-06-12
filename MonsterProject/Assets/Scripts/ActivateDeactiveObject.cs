using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactiveObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToChange;
    [SerializeField] private List<GameObject> ObjectsToChange = new List<GameObject>();
    [SerializeField] private List<GameObject> SecondaryObjectsList = new List<GameObject>();
    [SerializeField] private float delay = 0.1f;

    private bool delayOver = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && delayOver)
        {
            StartCoroutine(Delay(delay));

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && delayOver)
        {
            StartCoroutine(Delay2(delay));
        }
    }

    IEnumerator Delay(float delayAmount)
    {
        delayOver = false;
        if (SecondaryObjectsList.Count > 0)
        {
            foreach (GameObject obj in SecondaryObjectsList)
            {
                obj.SetActive(boolToggle(obj.activeInHierarchy));
            }
        }

        yield return new WaitForSeconds(delayAmount);

        if (objectToChange != null)
            objectToChange.SetActive(objectToChange.activeInHierarchy);

        if (ObjectsToChange.Count > 0)
        {
            foreach (GameObject obj in ObjectsToChange)
            {
                obj.SetActive(boolToggle(obj.activeInHierarchy));
            }
        }
        delayOver = true;
    }

    IEnumerator Delay2(float delayAmount)
    {
        delayOver = false;
        if (ObjectsToChange.Count > 0)
        {
            foreach (GameObject obj in ObjectsToChange)
            {
                obj.SetActive(boolToggle(obj.activeInHierarchy));
            }
        }

        yield return new WaitForSeconds(delayAmount);

        if (objectToChange != null)
            objectToChange.SetActive(objectToChange.activeInHierarchy);

        if (SecondaryObjectsList.Count > 0)
        {
            foreach (GameObject obj in SecondaryObjectsList)
            {
                obj.SetActive(boolToggle(obj.activeInHierarchy));
            }
        }
        delayOver = true;
    }


    bool boolToggle(bool boolean)
    {
        bool varBool = boolean;
        return varBool = varBool ? false : true;
    }

}
