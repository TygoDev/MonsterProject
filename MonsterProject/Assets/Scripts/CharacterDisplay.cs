using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterDisplay : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private int amountOfPlayersHovering;
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;
    private GameManager gameManager;

    public Character Character => character;

    public void OnDeselect(BaseEventData eventData)
    {
        amountOfPlayersHovering--;
        UpdateButtonColor();
    }

    public void OnSelect(BaseEventData eventData)
    {
        amountOfPlayersHovering++;
        UpdateButtonColor();
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

    private void UpdateButtonColor()
    {
        ColorBlock colors = button.colors;
        colors.normalColor = amountOfPlayersHovering >= 1 ? Color.green : Color.white;
        button.colors = colors;
    }
}
