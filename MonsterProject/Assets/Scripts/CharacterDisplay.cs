using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;
    GameManager gameManager;

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
