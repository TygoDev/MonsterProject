using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    Movement playerScript;
    bool playerStillOnPlatform;

    public float timeTofall = 2f;

    bool isBack = true;
    public float timeToComeBack = 2f;

    Coroutine coroutine;

    public bool disableOnPlatformBoolFromPlayer = false; // for the last tile that falls otherwise it will always be on a platform

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isBack && other.CompareTag(Tags.T_Player))
        {
            playerScript = other.GetComponent<Movement>();
            playerScript.isOnPlatform = true;
            playerStillOnPlatform = true;
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
            playerStillOnPlatform = false;
            if(disableOnPlatformBoolFromPlayer)
            {
                playerScript.isOnPlatform = false;
            }
        }
    }

    IEnumerator DisableOnPlatform()
    {
        float t = 0f;
        isBack = false;
        while (t <= timeTofall)
        {
            t += Time.deltaTime;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(1f, 0f, t));
        }

        if (playerStillOnPlatform)
        {
            playerScript.isOnPlatform = false; //will make it fall in the pit and reset his position        
        }
        coroutine = StartCoroutine(FadeBack());
        
        yield return null;
    }

    IEnumerator FadeBack()
    {
        float t = 0f;
        playerStillOnPlatform = false;
        while (t <= timeToComeBack)
        {
            t += Time.deltaTime;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(0f, 1f, t));
        }
        coroutine = null;
        isBack = true;
        yield return null;
    }
}
