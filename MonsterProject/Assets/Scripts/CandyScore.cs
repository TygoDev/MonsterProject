using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScore : MonoBehaviour
{
    public int scoreValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Player))
        {
            GameManager.Instance.AddScore(scoreValue);
        }
    }
}
