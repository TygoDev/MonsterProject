using UnityEngine;
using UnityEngine.UI;

public class AddOnclick : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private Button button;

    [SerializeField] private bool hasToChangeTheSceneIndex = false;
    [SerializeField] private bool hasToLoadALevel = false;
    [SerializeField] private int levelIndexToLoadInCharacterScreen = 0;

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
        SceneSwitcher.Instance.SwitchToScene(sceneIndex);
    }
}
