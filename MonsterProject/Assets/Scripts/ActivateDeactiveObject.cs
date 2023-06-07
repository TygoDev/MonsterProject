using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactiveObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToChange;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            objectToChange.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            objectToChange.SetActive(true);
    }
}
