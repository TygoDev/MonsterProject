using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncAnimatior : MonoBehaviour
{
    private void Start()
    {
        var animator = GetComponent<Animator>();
        animator.Play("Defaul", 0, Random.Range(0f,1f)); 
    }
}
