using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSheet : MonoBehaviour
{
    private Sprite sprite;
    private Sprite footPrint;
    private new string name;
    private string species;

    [SerializeField] private Image spriteImage;
    [SerializeField] private Image footPrintImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text speciesText;

    bool locked = false;

    public void SetInfo(Character character)
    {
        if (locked)
            return;

        sprite = character.sprite;
        footPrint = character.footPrint;
        name = character.name;
        species = character.species;

        spriteImage.sprite = sprite;
        footPrintImage.sprite = footPrint;
        nameText.text = "Name: " + name;
        speciesText.text = "Species: " + species;
    }

    public void SetLocked()
    {
        locked = true;
    }
}
