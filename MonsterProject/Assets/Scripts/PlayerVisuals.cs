using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance.GetPlayerOne().sprite != null)
            GetComponent<SpriteRenderer>().sprite = GameManager.Instance.GetPlayerOne().sprite;
    }
}
