using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnActiveAtStartOfScene : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false); 
    }
}
