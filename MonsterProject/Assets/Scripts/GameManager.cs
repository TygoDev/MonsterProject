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

    public Character player1Character;
    public Character player2Character;

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
