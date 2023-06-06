using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] GameManager.Levels levelToUnlock;

    [SerializeField] int nextLevelToLoad;

    public int level;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Player))
        {
            switch(levelToUnlock)
            {
                case GameManager.Levels.FOREST:
                    GameManager.Instance.unlockForest = true;
                    break;

                case GameManager.Levels.CRYSTAL:
                    GameManager.Instance.unlockCrystal = true;
                    break;

                case GameManager.Levels.CANDY:
                    GameManager.Instance.unlockCandy = true;
                    break;
            }
            GameManager.Instance.levelIndexToLoad = nextLevelToLoad;

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, GameManager.Instance.candyCount);
            SceneSwitcher.Instance.SwitchToScene(level);
        }
    }
}
