using UnityEngine;
using UnityEngine.UI;

public class AddOnclick : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchToScene);
    }

    private void SwitchToScene()
    {
        SceneSwitcher.Instance.SwitchToScene(sceneIndex);
    }
}
