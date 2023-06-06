using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            SceneSwitcher.Instance.SwitchToScene(level);
        }
    }
}
