using UnityEngine;
using UnityEngine.UI;

public class AddOnclick : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private Button button;

    [SerializeField] private bool hasToChangeTheSceneIndex = false;
    [SerializeField] private bool hasToLoadALevel = false;
    [SerializeField] private int levelIndexToLoadInCharacterScreen = 0;
    [SerializeField] bool isStartButton;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchToScene);

        if(hasToChangeTheSceneIndex)
        {
            sceneIndex = GameManager.Instance.levelIndexToLoad;
        }
    }

    private void SwitchToScene()
    {
        if(hasToLoadALevel)
        {
            GameManager.Instance.levelIndexToLoad = levelIndexToLoadInCharacterScreen;
        }
        if (!isStartButton)
        {
            SceneSwitcher.Instance.SwitchToScene(sceneIndex);
        }
        else
            if (GameManager.Instance.BothCharactersSelected())
        {
            SceneSwitcher.Instance.SwitchToScene(sceneIndex);
        }
    }
}
