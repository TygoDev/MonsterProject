using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] Character character;

    private void Start()
    {
        GetComponent<Image>().sprite = character.sprite;
    }
}
