using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterDisplay : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;
    [SerializeField] private CharacterSheet characterSheet;
    GameManager gameManager;

    public Character GetCharacter()
    {
        return character;
    }


    public void OnSelect(BaseEventData eventData)
    {
        playerText.gameObject.SetActive(true);
    }

    public void OnDeselect(BaseEventData data)
    {
        playerText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        gameManager = GameManager.Instance;
        button.onClick.AddListener(() => gameManager.SelectCharacter(character));
        button.image.sprite = character.sprite;
        button.onClick.AddListener(RegisterPlayer);
    }

    private void RegisterPlayer()
    {
        characterSheet.SetLocked();
    }
}
