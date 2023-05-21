using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGateAtEnd : MonoBehaviour
{
    public int numberOfKeysRequired;

    OpenDoor openDoor;

    [SerializeField] TMP_Text moreKeysRequired;

    private void Start()
    {
        openDoor = GetComponent<OpenDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Player))
        {
            if(numberOfKeysRequired == GameManager.Instance.candyCount)
            {
                openDoor.activeCorutine = StartCoroutine(openDoor.OpenOrCloseDoor(openDoor.doorPath, openDoor.door, openDoor.timeToOpen, true));
            }
            else
            {
                StartCoroutine(FadeText());
            }
        }
    }

    IEnumerator FadeText()
    {
        float t = 0f;

        moreKeysRequired.text = "Je hebt nog " + (numberOfKeysRequired - GameManager.Instance.candyCount) +  " sleutels nodig.";
        while (t < 1f)
        {
            t += Time.deltaTime;
            moreKeysRequired.alpha = Mathf.Lerp(0f, 1f, t);
        }

        yield return null;
    }
}
