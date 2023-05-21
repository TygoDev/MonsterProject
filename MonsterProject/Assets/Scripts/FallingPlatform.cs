using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Curve platformPath;

    [SerializeField] GameObject otherplatform;
    [SerializeField] Curve closeotherPlatformCurve;

    [SerializeField] float timeToOpen = 1f;

    [SerializeField] bool closeOnExitTrigger = false;

    [SerializeField] float timeToClose = 3f;
    Coroutine activeCorutine = null;

    IEnumerator OpenOrCloseDoor(Curve path, GameObject door, float timeToMove, bool openDoor = true)
    {
        var currentPos = door.transform.position;
        var t = 0f;

        if (openDoor && door.transform.position == path.GetPoint(1))
        {
            yield break;
        }
        if (!openDoor && door.transform.position == path.GetPoint(0))
        {
            yield break;
        }

        while (t <= 1f)
        {
            t += Time.deltaTime / timeToMove;
            if (openDoor)
            {
                door.transform.position = Vector3.Lerp(currentPos, path.GetPoint(1), t);
            }
            else
            {
                door.transform.position = Vector3.Lerp(currentPos, path.GetPoint(0), t);
            }
            yield return null;
        }
        if (openDoor)
        {
            door.transform.position = path.GetPoint(1);
            door.GetComponent<SpriteRenderer>().sortingOrder = 3;
            this.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        else
        {
            door.transform.position = path.GetPoint(0);
            door.GetComponent<SpriteRenderer>().sortingOrder = -1;
            this.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(Tags.T_Player))
        {
            if (activeCorutine == null)
            {
                activeCorutine = StartCoroutine(OpenOrCloseDoor(platformPath, platform, timeToOpen, true));
            }
            else
            {
                StopCoroutine(activeCorutine);
                activeCorutine = StartCoroutine(OpenOrCloseDoor(platformPath, platform, timeToOpen, true));
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(otherplatform != null && collision.CompareTag(Tags.T_Player))
        {
            activeCorutine = StartCoroutine(OpenOrCloseDoor(closeotherPlatformCurve, otherplatform, timeToClose, false));
            return;
        }
        if (collision.CompareTag(Tags.T_Player))
        {
            if (closeOnExitTrigger)
            {
                if (activeCorutine == null)
                {
                    activeCorutine = StartCoroutine(OpenOrCloseDoor(platformPath, platform, timeToClose, false));
                }
                else
                {
                    StopCoroutine(activeCorutine);
                    activeCorutine = StartCoroutine(OpenOrCloseDoor(platformPath, platform, timeToClose, false));
                }
            }
        }
    }
}
