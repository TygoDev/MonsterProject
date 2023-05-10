using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddOnclick : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneSwitcher.Instance.SwitchToScene(sceneIndex));
    }
}
