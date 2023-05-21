using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpoint;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(Tags.T_Player))
        {
            collision.GetComponent<Movement>().checkpoint = this.checkpoint;
        }

    }
}
