using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public GameManager.Levels levelToUnlock;
    private void Start()
    {
        TMP_Text component;
        Button button;
        switch (levelToUnlock)
        {
            case GameManager.Levels.FOREST:
                if (TryGetComponent<TMP_Text>(out component))
                {
                    if(GameManager.Instance.unlockForest)
                        component.gameObject.SetActive(false);
                }
                if(TryGetComponent<Button>(out button))
                {
                    if (GameManager.Instance.unlockForest)
                        button.interactable = true;
                }
                break;

            case GameManager.Levels.CRYSTAL:
                if (TryGetComponent<TMP_Text>(out component))
                {
                    if (GameManager.Instance.unlockCrystal)
                        component.gameObject.SetActive(false);
                }
                if (TryGetComponent<Button>(out button))
                {
                    if (GameManager.Instance.unlockCrystal)
                        button.interactable = true;
                }
                break;

            case GameManager.Levels.CANDY:
                if (TryGetComponent<TMP_Text>(out component))
                {
                    if (GameManager.Instance.unlockCandy)
                        component.gameObject.SetActive(false);
                }
                if (TryGetComponent<Button>(out button))
                {
                    if (GameManager.Instance.unlockCandy)
                        button.interactable = true;
                }
                break;
        }
    }
}
