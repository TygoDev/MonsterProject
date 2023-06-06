using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCanvasAtEnd : MonoBehaviour
{
    [SerializeField] GameObject playerOneInput;
    [SerializeField] GameObject playerTwoInput;

    [SerializeField] GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Player))
        {
            playerOneInput.SetActive(true);
            playerTwoInput.SetActive(true);
            canvas.SetActive(true);
        }
    }
}
