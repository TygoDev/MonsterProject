using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Character player1Character;
    public Character player2Character;

    [SerializeField] GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    void ChangedActiveScene(Scene current, Scene next)
    {
        if(next.name.Contains("Movement")) //change to level, we will call the scenes with puzzles Level_number
        {
            var p1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[0]);
            //Debug.Log(Gamepad.all[0]);
            p1.gameObject.GetComponent<SpriteRenderer>().sprite = player1Character.sprite;
            var p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard&Mouse");
            p2.gameObject.GetComponent<SpriteRenderer>().sprite = player2Character.sprite;
        }
    }

    public bool BothCharactersSelected()
    {
        if (Player1Selected() && Player2Selected())
            return true;
        else
            return false;
    }

    public void SelectCharacter(Character character, int playerNumber)
    {
        if(playerNumber == 1)
            player1Character = character;
        else if(playerNumber == 2)
            player2Character = character;
    }

    public bool Player1Selected()
    {
        if (player1Character == null)
            return false;
        else
            return true;
    }

    public bool Player2Selected()
    {
        if (player2Character == null)
            return false;
        else
            return true;
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
