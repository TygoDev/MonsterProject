using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class TestSomething : MonoBehaviour
{
    private EventSystem eventSystem;
    private InputSystemUIInputModule inputModule;

    private void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();
        inputModule = FindObjectOfType<InputSystemUIInputModule>();
    }

    public void Test()
    {
        Debug.Log(eventSystem.currentSelectedGameObject.name);
    }
}
