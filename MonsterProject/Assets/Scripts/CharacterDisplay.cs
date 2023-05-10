using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterDisplay : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Character character;
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;
    GameManager gameManager;


    public void OnSelect(BaseEventData eventData)
    {
        playerText.gameObject.SetActive(true);
        characterImage.sprite = character.sprite;
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

    void RegisterPlayer()
    {
        if (!gameManager.Player2Selected() && gameManager.Player1Selected())
            playerText.text = "Player 1";

        if (gameManager.Player2Selected() && gameManager.Player1Selected())
            playerText.text = "Player 2";

        button.interactable = false;
    }
}
