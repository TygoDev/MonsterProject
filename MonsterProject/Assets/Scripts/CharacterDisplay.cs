using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterDisplay : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;
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
        button.image.sprite = character.sprite;
    }
}
