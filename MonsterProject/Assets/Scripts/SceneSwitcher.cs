using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneSwitcher : MonoBehaviour
{
    private static SceneSwitcher instance;
    public static SceneSwitcher Instance { get { return instance; } }

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

    public void SwitchToScene(int index)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex: index);
        if(!asyncLoad.isDone)
        {
            var a = GameObject.FindGameObjectsWithTag(Tags.T_UISCInput);
            foreach(var b in a)
            {
                Destroy(b);
            }
        }
    }
}
