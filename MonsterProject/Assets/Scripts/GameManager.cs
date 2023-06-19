using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

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

    public int candyCount = 0;

    public int scoreInScene = 0;
    public int totalScore = 0;

    public TMP_Text candyCountText;

    public enum Levels
    {
        FOREST,
        CRYSTAL,
        CANDY
    }

    [HideInInspector]
    public bool unlockForest = false;
    [HideInInspector]
    public bool unlockCrystal = false;
    [HideInInspector]
    public bool unlockCandy = false;

    public int levelIndexToLoad;

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

    public void AddScore(int scoreToAdd)
    {
        scoreInScene += scoreToAdd;
        totalScore += scoreToAdd;
        candyCountText.text = candyCount.ToString();
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {

        if (next.name.Contains("Level")) //change to level, we will call the scenes with puzzles Level_number
        {
            candyCount = 0;
            //if(!next.name.Contains("Tutorial"))
            try
            {
                candyCountText = GameObject.FindGameObjectWithTag(Tags.T_CandyCount).GetComponent<TMP_Text>();
            }
            catch
            {
                Debug.LogWarning("No candy text in this scene!");
            }
            GameObject[] spawns = GameObject.FindGameObjectsWithTag(Tags.T_Spawn);
            GameObject[] lifes = GameObject.FindGameObjectsWithTag(Tags.T_Lifes);
            if (playerPrefab != null && SceneManager.GetActiveScene().name != "Level_Selection")
            {
                var p1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Joystick", pairWithDevice: Joystick.all[1]);
                var p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Joystick", pairWithDevice: Joystick.all[0]);

                //var p1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard&Mouse");
                //var p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard&Mouse");

                SetPlayerSprite(p1.gameObject, player1Character);
                SetPlayerSprite(p2.gameObject, player2Character);

                p1.GetComponent<Movement>().footstepPrefab = player1Character.footPrint;
                p2.GetComponent<Movement>().footstepPrefab = player2Character.footPrint;
               
                for (int i = 0; i < spawns.Length; i++)
                {
                    if (spawns[i].name.Contains("1"))
                    {
                        p1.transform.position = spawns[i].transform.position;
                        p1.GetComponent<Movement>().checkpoint = spawns[i].transform;
                    }
                    else
                    {
                        p2.transform.position = spawns[i].transform.position;
                        p2.GetComponent<Movement>().checkpoint = spawns[i].transform;
                    }
                }
                for (int i = 0; i < lifes.Length; i++)
                {
                    if (lifes[i].name.Contains("1"))
                    {
                        for (int j = 0; j < lifes[i].transform.childCount; j++)
                        {
                            p1.GetComponent<Movement>().canvasLives.Add(lifes[i].transform.GetChild(j));
                        }
                        //p1.GetComponent<Movement>().canvasLives.AddRange(lifes[i].GetComponentsInChildren<Transform>());
                        //p1.GetComponent<Movement>().canvasLives.RemoveAt(0);
                    }
                    else
                    {
                        for (int j = 0; j < lifes[i].transform.childCount; j++)
                        {
                            p2.GetComponent<Movement>().canvasLives.Add(lifes[i].transform.GetChild(j));
                        }
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
