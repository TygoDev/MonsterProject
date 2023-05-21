using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Player))
        {
            SceneSwitcher.Instance.SwitchToScene(0);
        }
    }
}
