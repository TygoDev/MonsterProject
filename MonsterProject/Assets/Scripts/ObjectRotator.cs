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
            //float angle = i * (360f / numPrefabs);

            float theta = (2 * Mathf.PI / numPrefabs) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);

            Vector3 spawnPosition = transform.position + new Vector3(xPos, yPos, 0f) * radius;
            spawnedPrefabs[i] = Instantiate(prefab.gameObject, spawnPosition, Quaternion.Euler(-45,0,180), this.transform);
        }

    }

    private void Update()
    {
        for (int i = 0; i < numPrefabs; i++)
        {

            float angle = Time.time * orbitSpeed;
            float theta = (2 * Mathf.PI / numPrefabs) * i;
            float x = Mathf.Cos(angle + theta) * radius;
            float y = Mathf.Sin(angle + theta) * radius;

            Vector3 newPosition = new Vector3(x + transform.position.x, y + transform.position.y, spawnedPrefabs[i].transform.position.z);
            spawnedPrefabs[i].transform.position = newPosition;
        }
    }
}
