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

    public GameObject player1;
    public GameObject player2;

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
        if (next.name.Contains("Level")) //change to level, we will call the scenes with puzzles Level_number
        {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag(Tags.T_Spawn);
            if (playerPrefab != null)
            {
                var p1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[1]);
                var p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[0]);

                //var p1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard&Mouse");
                //var p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard&Mouse");

                SetPlayerSprite(p1.gameObject, player1Character);
                SetPlayerSprite(p2.gameObject, player2Character);

                for (int i = 0; i < spawns.Length; i++)
                {
                    if(spawns[i].name.Contains("1"))
                    {
                        p1.transform.position = spawns[i].transform.position;
                    }
                    else
                    {
                        p2.transform.position = spawns[i].transform.position;
                    }
                }

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
