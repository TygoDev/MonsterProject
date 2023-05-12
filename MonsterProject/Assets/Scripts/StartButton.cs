using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button startButton;

    public void MakeButtonVisible()
    {
        if (GameManager.Instance.BothCharactersSelected())
            startButton.gameObject.SetActive(true);
    }
}
