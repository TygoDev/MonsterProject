using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private Button button;
    GameManager gameManager;

    public Character GetCharacter()
    {
        return character;
    }

    public void SetSelected(int playerNumber)
    {
        playerText.gameObject.SetActive(true);
        GetComponent<Outline>().enabled = true;
        playerText.text = playerNumber.ToString();
    }

    public void DeSelect()
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
