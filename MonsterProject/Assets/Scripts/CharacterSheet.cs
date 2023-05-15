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
    private Character character;

    [SerializeField] private int playerNumber;
    [SerializeField] private Image spriteImage;
    [SerializeField] private Image footPrintImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text speciesText;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private InputSystemUIInputModule inputModule;
    private CharacterDisplay characterDisplaySelected;

    bool locked = false;

    private void Start()
    {
        characterSheet = eventSystem.firstSelectedGameObject;
        character = characterSheet.GetComponent<CharacterDisplay>().GetCharacter();

        sprite = character.sprite;
        footPrint = character.footPrint;
        name = character.name;
        species = character.species;

        spriteImage.sprite = sprite;
        footPrintImage.sprite = footPrint;
        nameText.text = "Name: " + name;
        speciesText.text = "Species: " + species;
    }

    public void SetInfo()
    {
        if (!locked)
        {
            characterSheet = eventSystem.currentSelectedGameObject;

            if (characterSheet.GetComponent<CharacterDisplay>() != null)
            {
                character = characterSheet.GetComponent<CharacterDisplay>().GetCharacter();

                sprite = character.sprite;
                footPrint = character.footPrint;
                name = character.name;
                species = character.species;

                spriteImage.sprite = sprite;
                footPrintImage.sprite = footPrint;
                nameText.text = "Name: " + name;
                speciesText.text = "Species: " + species;
            }
        }
    }

    public void SelectCharacter()
    {
        
        characterSheet = eventSystem.currentSelectedGameObject;
        if (characterSheet.GetComponent<CharacterDisplay>() != null)
            character = characterSheet.GetComponent<CharacterDisplay>().GetCharacter();

        if (GameManager.Instance.GetPlayerOne() == character || GameManager.Instance.GetPlayerTwo() == character)
        {
            return;
        }
        if (characterDisplaySelected != null)
            characterDisplaySelected.UnsetHover();

        characterDisplaySelected = characterSheet.GetComponent<CharacterDisplay>();
        characterSheet.GetComponent<CharacterDisplay>().SetHover(playerNumber);

        GetComponent<Outline>().enabled = true;
        locked = true;

        sprite = character.sprite;
        footPrint = character.footPrint;
        name = character.name;
        species = character.species;

        spriteImage.sprite = sprite;
        footPrintImage.sprite = footPrint;
        nameText.text = "Name: " + name;
        speciesText.text = "Species: " + species;



        if (eventSystem.currentSelectedGameObject.GetComponent<CharacterDisplay>() != null)
        {
            GameManager.Instance.SelectCharacter(character, playerNumber);
        }
    }
}
