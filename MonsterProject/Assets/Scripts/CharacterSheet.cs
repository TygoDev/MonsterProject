using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;

public class CharacterSheet : MonoBehaviour
{
    private Sprite sprite;
    private Sprite footPrint;
    private new string name;
    private string species;
    private GameObject characterSheet;

    [SerializeField] private Image spriteImage;
    [SerializeField] private Image footPrintImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text speciesText;

    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private InputSystemUIInputModule inputModule;

    bool locked = false;

    public void SetInfo()
    {
        characterSheet = eventSystem.currentSelectedGameObject;
        
        if(characterSheet.GetComponent<CharacterDisplay>() != null)
        {
            Character info = characterSheet.GetComponent<CharacterDisplay>().GetCharacter();

            sprite = info.sprite;
            footPrint = info.footPrint;
            name = info.name;
            species = info.species;

            spriteImage.sprite = sprite;
            footPrintImage.sprite = footPrint;
            nameText.text = "Name: " + name;
            speciesText.text = "Species: " + species;
        }
    }

    public void SetLocked()
    {
        locked = true;
    }
}
