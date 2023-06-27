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
                if (GameManager.Instance.candyCount > 11)
                    stars[0].sprite = starSprite;
                if (GameManager.Instance.candyCount > 30)
                    stars[0].sprite = starSprite;
                if (GameManager.Instance.candyCount > 60)
                    stars[0].sprite = starSprite;
            
        }
        if (SceneManager.GetActiveScene().name.Contains("Crystal"))
        {
                if (GameManager.Instance.candyCount > 26)
                    stars[0].sprite = starSprite;
                if (GameManager.Instance.candyCount > 70)
                    stars[0].sprite = starSprite;
                if (GameManager.Instance.candyCount > 140)
                    stars[0].sprite = starSprite;
            
        }
        if (SceneManager.GetActiveScene().name.Contains("Candy"))
        {
                if (GameManager.Instance.candyCount > 41)
                    stars[0].sprite = starSprite;
                if (GameManager.Instance.candyCount > 110)
                    stars[0].sprite = starSprite;
                if (GameManager.Instance.candyCount > 220)
                    stars[0].sprite = starSprite;
            
        }

    }
}
