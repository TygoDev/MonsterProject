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

    public bool locked = false;

    private void Start()
    {
        InitializeCharacterSheet();
    }

    public void SetInfo()
    {
        if (!locked)
        {
            characterSheet = eventSystem.currentSelectedGameObject;

            if (characterSheet != null && characterSheet.TryGetComponent(out CharacterDisplay characterDisplay))
            {
                character = characterDisplay.Character;
                UpdateCharacterInfo();
            }
        }
    }

    private void Update()
    {
        if (eventSystem.currentSelectedGameObject != null && eventSystem.currentSelectedGameObject.GetComponent<CharacterDisplay>() && !locked)
        {
            character = eventSystem.currentSelectedGameObject.GetComponent<CharacterDisplay>().Character;
            UpdateCharacterInfo();
        }
    }


    public void SelectCharacter()
    {
        characterSheet = eventSystem.currentSelectedGameObject;

        if (characterSheet.TryGetComponent(out CharacterDisplay characterDisplay))
        {
            character = characterDisplay.Character;

            if (GameManager.Instance.GetPlayerOne() == character || GameManager.Instance.GetPlayerTwo() == character)
            {
                return;
            }

            if (characterDisplaySelected != null)
            {
                characterDisplaySelected.UnsetHover();
            }

            characterDisplaySelected = characterDisplay;
            characterDisplay.SetHover(playerNumber);

            GetComponent<Outline>().enabled = true;
            locked = true;

            UpdateCharacterInfo();

            GameManager.Instance.SelectCharacter(character, playerNumber);
        }
    }

    private void InitializeCharacterSheet()
    {
        characterSheet = eventSystem.firstSelectedGameObject;
        if (characterSheet.TryGetComponent(out CharacterDisplay characterDisplay))
        {
            character = characterDisplay.Character;
            UpdateCharacterInfo();
        }
    }

    private void UpdateCharacterInfo()
    {
        sprite = character.sprite;
        footPrint = character.footPrintSprite;

        spriteImage.sprite = sprite;
        footPrintImage.sprite = footPrint;
    }
}
