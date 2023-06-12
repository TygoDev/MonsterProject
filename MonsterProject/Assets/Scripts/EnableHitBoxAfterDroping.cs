using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHitBoxAfterDroping : MonoBehaviour
{
    BoxCollider bc;
    private void Awake()
    {
        bc = GetComponent<BoxCollider>();  
        StartCoroutine(EnableHitBox());
    }

    IEnumerator EnableHitBox()
    {
        yield return new WaitForSeconds(1f);
        bc.enabled = true;
    }
}
