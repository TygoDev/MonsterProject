using UnityEngine;
using System;

public class ObjectRotator : MonoBehaviour
{
    public Transform prefab;          // The prefab to be spawned and rotated
    public int numPrefabs = 6;        // Number of prefabs to be spawned
    public float radius = 5f;
    public float orbitSpeed = 5f;

    public GameObject[] spawnedPrefabs;  // Array to hold the spawned prefabs

    private void Start()
    {
        spawnedPrefabs = new GameObject[numPrefabs];

        // Spawn the prefabs
        for (int i = 0; i < numPrefabs; i++)
        {
            float angle = i * 360f / numPrefabs;
            Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, 0f, angle) * Vector3.right * radius;
            spawnedPrefabs[i] = Instantiate(prefab.gameObject, spawnPosition, Quaternion.Euler(-45,0,0));
        }

    }

    private void Update()
    {
        for (int i = 0; i < numPrefabs; i++)
        {
            float angle = Time.time * orbitSpeed;
            float x = Mathf.Cos(angle + i) * radius;
            float y = Mathf.Sin(angle + i) * radius;

            Vector3 newPosition = new Vector3(x + transform.position.x, y + transform.position.y, spawnedPrefabs[i].transform.position.z);
            spawnedPrefabs[i].transform.position = newPosition;
        }
    }
}
