using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCandies : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    [SerializeField] GameManager.Levels level;

    private void Awake()
    {
        switch(level)
        {
            case GameManager.Levels.FOREST:
                try
                {
                    text.text = PlayerPrefs.GetInt("Level_forest").ToString();
                }
                catch
                {
                    text.text = "0";
                }
                break;
            case GameManager.Levels.CRYSTAL:
                try
                {
                    text.text = PlayerPrefs.GetInt("Level_Crystal").ToString();
                }
                catch
                {
                    text.text = "0";
                }
                break;
            case GameManager.Levels.CANDY:
                try
                {
                    text.text = PlayerPrefs.GetInt("Level_Candy").ToString();
                }
                catch
                {
                    text.text = "0";
                }
                break;
        }
        //text = GetComponent<TMP_Text>();
    }
}
