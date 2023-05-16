using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Character player1Character;
    public Character player2Character;

    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            SceneManager.activeSceneChanged += ChangedActiveScene;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (next.name.Contains("Movement")) //change to level, we will call the scenes with puzzles Level_number
        {
            if (playerPrefab != null)
            {
                var p1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[1]);
                var p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[0]);

                SetPlayerSprite(p1.gameObject, player1Character);
                SetPlayerSprite(p2.gameObject, player2Character);
            }
        }
    }

    private void SetPlayerSprite(GameObject playerObject, Character character)
    {
        if (playerObject != null && character != null)
        {
            var spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = character.sprite;
            }
        }
    }

    public bool BothCharactersSelected()
    {
        return Player1Selected() && Player2Selected();
    }

    public void SelectCharacter(Character character, int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Character = character;
        }
        else if (playerNumber == 2)
        {
            player2Character = character;
        }
    }

    public bool Player1Selected()
    {
        return player1Character != null;
    }

    public bool Player2Selected()
    {
        return player2Character != null;
    }

    public Character GetPlayerOne()
    {
        return player1Character;
    }

    public Character GetPlayerTwo()
    {
        return player2Character;
    }
}
