using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class StopEnemy : MonoBehaviour
{
    ObjectRotator rotatingParent;
    WaypointAgent waypointAgent;

    [SerializeField] float timerToDisable = 4f;

    //[HideInInspector]
    public bool disabled = false;

    private void Awake()
    {
        if(this.transform.parent != null)
        {
            this.transform.parent.TryGetComponent<ObjectRotator>(out rotatingParent);
        }

        this.TryGetComponent<WaypointAgent>(out waypointAgent);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Bullet))
        {
            if (!disabled)
            {
                disabled = true;
                StartCoroutine(DisableMovement());
                if(rotatingParent != null)
                {
                    foreach (Transform child in rotatingParent.transform)
                    {
                        Debug.Log("1 child");
                        var a = child.gameObject.GetComponent<StopEnemy>();
                        a.disabled = true;
                        a.StartCoroutine(a.Wiggle());
                    }
                }
                else
                {
                    StartCoroutine(Wiggle());
                }

            }
            Destroy(other);
        }
    }

    IEnumerator Wiggle()
    {
        var oldPosition = this.transform.position;

        while(disabled)
        {
            float angle = Time.time * 2f;
            //float theta = (2 * Mathf.PI / numPrefabs) * i;
            float x = Mathf.Cos(angle) * 1f;
            float y = Mathf.Sin(angle) * 1f;

            Vector3 newPosition = new Vector3(x + oldPosition.x, y + oldPosition.y, oldPosition.z);
            this.transform.position = newPosition;
            yield return null;
        }

        //Debug.Log("I finished wiggle");
        foreach (Transform child in rotatingParent.transform)
        {
            child.gameObject.GetComponent<StopEnemy>().disabled = false;
        }
        transform.position = oldPosition;
        yield return null;
    }
    IEnumerator DisableMovement()
    {
        if (rotatingParent != null)
        {
            var a = rotatingParent.orbitSpeed;
            rotatingParent.orbitSpeed = 0;
            yield return new WaitForSeconds(timerToDisable);
            rotatingParent.orbitSpeed = a;
        }

        if(waypointAgent != null)
        {
            var a = waypointAgent.speed;
            waypointAgent.speed = 0;
            yield return new WaitForSeconds(timerToDisable);
            waypointAgent.speed = a;
        }
        disabled = false;

        yield return null;
    }
}
