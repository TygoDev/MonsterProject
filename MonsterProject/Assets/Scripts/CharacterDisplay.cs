using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterDisplay : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    int amountOfPlayersHovering;
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;
    GameManager gameManager;

    public Character GetCharacter()
    {
        return character;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        amountOfPlayersHovering--;
        if (amountOfPlayersHovering == 0)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.white;
            button.colors = colors;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        amountOfPlayersHovering++;
        if (amountOfPlayersHovering >= 1)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.green;
            button.colors = colors;
        }
    }

    public void SetHover(int playerNumber)
    {
        playerText.gameObject.SetActive(true);
        GetComponent<Outline>().enabled = true;
        playerText.text = playerNumber.ToString();
    }

    public void UnsetHover()
    {
        playerText.gameObject.SetActive(false);
        GetComponent<Outline>().enabled = false;
    }

    private void Awake()
    {
        gameManager = GameManager.Instance;
        button.image.sprite = character.sprite;
    }
}
