using UnityEngine;
using UnityEngine.InputSystem;
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
        if(readValue == 0)
        Debug.Log("I am swiching the scene");
        /*var asyncLoad = */SceneManager.LoadSceneAsync(sceneBuildIndex: index);
        /*if(!asyncLoad.isDone)
        {
            var a = GameObject.FindGameObjectsWithTag(Tags.T_UISCInput);
            foreach(var b in a)
            {
                Destroy(b);
            }
        }*/
    }

    public float readValue;
    public void ReturnPressedValue(InputAction.CallbackContext context)
    {
        readValue = context.ReadValue<float>();
    }
}
