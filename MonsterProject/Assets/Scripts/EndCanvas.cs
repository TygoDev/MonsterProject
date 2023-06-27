using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    public List<Image> stars = new List<Image>();
    public TMP_Text CandyText;
    public TMP_Text ScoreText;
    public TMP_Text wonorlostText;
    public Button continueButton;
    bool lost = false;

    public Sprite starSprite;
    public void UpdateTheCanvas()
    {
        if (lost)
        {
            wonorlostText.text = "Game Over!";
            continueButton.gameObject.SetActive(false);
        }
        else
        {
            wonorlostText.text = "Success";
            continueButton.gameObject.SetActive(true);
        }

        CandyText.text = GameManager.Instance.candyCount.ToString();
        ScoreText.text = GameManager.Instance.scoreInScene.ToString();

        if(SceneManager.GetActiveScene().name.Contains("forest"))
        {
            if()
        }
    }
}
