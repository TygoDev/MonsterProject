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
    bool fadeIn;

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
                StartCoroutine(FadeText(fadeIn));
                fadeIn = true;
            }
        }
    }

    IEnumerator FadeText(bool fade)
    {
        float t = 0f;

        moreKeysRequired.text = "Je hebt nog " + (numberOfKeysRequired - GameManager.Instance.candyCount) +  " sleutels nodig.";
        while (t < 1f)
        {
            t += Time.deltaTime / 2f;
            if(!fade)
            {
                moreKeysRequired.alpha = Mathf.Lerp(0f, 1f, t);
            }
            else
            {
                moreKeysRequired.alpha = Mathf.Lerp(1f, 0f, t);
            }
            yield return null;
        }

        if(!fade)
        {
            StartCoroutine(FadeText(fadeIn));
            fadeIn = false;
        }
        yield return null;
    }
}
