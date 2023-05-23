using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    Movement playerScript;
    bool playerStillOnPlatform;

    public float timeTofall = 10f;

    bool isBack = true;
    public float timeToComeBack = 2f;

    Coroutine coroutine;

    public bool disableOnPlatformBoolFromPlayer = false; // for the last tile that falls otherwise it will always be on a platform

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine(DisableOnPlatform());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isBack && other.CompareTag(Tags.T_Player))
        {
            playerScript = other.GetComponent<Movement>();
            playerScript.isOnPlatform = true;
            playerStillOnPlatform = true;

            playerScript.platforms.Add(this.gameObject);
            if(coroutine == null)
            {
                coroutine = StartCoroutine(DisableOnPlatform());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.T_Player))
        {
            playerScript.platforms.Remove(this.gameObject);
            playerStillOnPlatform = false;
            /*if(disableOnPlatformBoolFromPlayer)
            {
                playerScript.isOnPlatform = false;
            }*/
        }
    }

    IEnumerator DisableOnPlatform()
    {
        //yield return new WaitForSeconds(3f);
        float t = 0f;
        isBack = false;
        while (t <= 1f)
        {
            t += Time.deltaTime / timeTofall;
            //Debug.Log(t);
            sprite.material.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(1f, 0f, t));
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        if (playerStillOnPlatform)
        {
            playerScript.isOnPlatform = false; //will make it fall in the pit and reset his position
            playerScript.ResetToCheckpoint();
        }
        yield return new WaitForSeconds(1f);
        coroutine = StartCoroutine(FadeBack());
        
        yield return null;
    }

    IEnumerator FadeBack()
    {
        float t = 0f;
        playerStillOnPlatform = false;
            Debug.Log("FadingBack");
        while (t <= 1f)
        {
            t += Time.deltaTime / timeToComeBack;
            sprite.material.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
        coroutine = null;
        isBack = true;
        yield return null;
    }
}
