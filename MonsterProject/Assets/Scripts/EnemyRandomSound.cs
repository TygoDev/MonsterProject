using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSound : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] List<AudioClip> clipList;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(RandomSound());
    }

    IEnumerator RandomSound()
    {
        audioSource.clip = clipList[Random.Range(0, clipList.Count)];
        audioSource.Play();
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        StartCoroutine(RandomSound());
    }
}
