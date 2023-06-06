using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTutorialIndex : MonoBehaviour
{
    Tutorial tutorial;

    private void Start()
    {
        tutorial = FindObjectOfType<Tutorial>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorial.NextText();
            Destroy(this);
        }
    }
}
