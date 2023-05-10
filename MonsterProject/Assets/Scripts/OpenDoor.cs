using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Curve doorPath;

    [SerializeField] float timeToOpen = 1f;

    [SerializeField] bool closeOnExitTrigger = false;

    [SerializeField] float timeToClose = 3f;
    Coroutine activeCorutine = null;

    IEnumerator OpenOrCloseDoor(Curve path, GameObject door, float timeToMove, bool openDoor = true)
    {
        var currentPos = door.transform.position;
        var t = 0f;

        if(openDoor && door.transform.position == path.GetPoint(1))
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
        }
        else
        {
            door.transform.position = path.GetPoint(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activeCorutine == null)
        {
            activeCorutine = StartCoroutine(OpenOrCloseDoor(doorPath, door, timeToOpen, true));
        }
        else
        {
            StopCoroutine(activeCorutine);
            activeCorutine = StartCoroutine(OpenOrCloseDoor(doorPath, door, timeToOpen, true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(closeOnExitTrigger)
        {
            if (activeCorutine == null)
            {
                activeCorutine = StartCoroutine(OpenOrCloseDoor(doorPath, door, timeToClose, false));
            }
            else
            {
                StopCoroutine(activeCorutine);
                activeCorutine = StartCoroutine(OpenOrCloseDoor(doorPath, door, timeToClose, false));
            }
        }
    }
}
