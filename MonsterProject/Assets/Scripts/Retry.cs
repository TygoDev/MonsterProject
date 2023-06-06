using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(SwitchToScene);
    }

    private void SwitchToScene()
    {
        SceneSwitcher.Instance.SwitchToScene(SceneManager.GetActiveScene().buildIndex);
    }
}
