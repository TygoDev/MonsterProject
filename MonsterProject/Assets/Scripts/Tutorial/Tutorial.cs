using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<string> linesInTutorial = new List<string>();
    [SerializeField] private Image arrowButtons;
    private TMP_Text text;
    private int index;

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        text.text = linesInTutorial[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            NextText();
    }

    public void NextText()
    {
        if(index + 1 < linesInTutorial.Count)
        {
            index++;
            text.text = linesInTutorial[index];
        }

        if (index != 0)
            arrowButtons.gameObject.SetActive(false);
        else
            arrowButtons.gameObject.SetActive(true);
    }
}
