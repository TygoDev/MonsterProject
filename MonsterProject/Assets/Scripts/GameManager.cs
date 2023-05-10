using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private Character player1Character;
    private Character player2Character;

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
    }

    public void SelectCharacter(Character character)
    {
        if (!Player1Selected())
            player1Character = character;
        else if (!Player2Selected())
            player2Character = character;

        if (Player1Selected() && Player2Selected())
            SceneSwitcher.Instance.SwitchToScene(2);
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
