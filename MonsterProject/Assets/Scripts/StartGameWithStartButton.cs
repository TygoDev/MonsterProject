using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameWithStartButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("A)");
        if(GameManager.Instance.BothCharactersSelected())
        {
            SceneSwitcher.Instance.SwitchToScene(GameManager.Instance.levelIndexToLoad);
        }
    }
}
