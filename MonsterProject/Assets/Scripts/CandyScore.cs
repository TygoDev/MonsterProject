using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyScore : MonoBehaviour
{
    public int scoreValue;

    [SerializeField] GameObject textPickUpPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.T_Player))
        {
            GameManager.Instance.AddScore(scoreValue);
            if (scoreValue > 0)
                textPickUpPrefab.GetComponentInChildren<TMP_Text>().text = "+" + scoreValue;
            else
                textPickUpPrefab.GetComponentInChildren<TMP_Text>().text = "";
            Instantiate(textPickUpPrefab, transform.position, Quaternion.identity);
        }
    }
}
