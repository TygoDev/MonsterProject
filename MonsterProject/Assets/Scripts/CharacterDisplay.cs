using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;

    private void Start()
    {
        button.image.sprite = character.sprite;
        button.onClick.AddListener(RegisterPlayer);
    }

    void RegisterPlayer()
    {
        if (!GameManager.Instance.Player2Selected() && GameManager.Instance.Player1Selected())
            playerText.text = "Player 1";

        if (GameManager.Instance.Player2Selected() && GameManager.Instance.Player1Selected())
            playerText.text = "Player 2";

        button.interactable = false;
    }
}
