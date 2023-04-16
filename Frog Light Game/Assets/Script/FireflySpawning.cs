using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySpawning : MonoBehaviour
{
    public GameObject objectPrefab; // The object to spawn
    public int numObjects = 25; // Number of objects to spawn
    public float respawnTime = 2f; // Time in seconds before a new object is respawned after destruction
    public Transform[] cornerPoints = new Transform[3];

    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to keep track of spawned objects

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numObjects; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(cornerPoints[0].position.x, cornerPoints[1].position.x), Random.Range(cornerPoints[1].position.y, cornerPoints[2].position.y));
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            spawnedObjects.Add(spawnedObject);
        }
    }

    void Update()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null) // If an object is destroyed
            {
                spawnedObjects.RemoveAt(i); // Remove it from the list
                StartCoroutine(RespawnObject()); // Respawn a new object using a coroutine
            }
        }
    }

    IEnumerator RespawnObject()
    {
        yield return new WaitForSeconds(respawnTime); // Wait for the specified respawn time
        Vector2 spawnPosition = new Vector2(Random.Range(cornerPoints[0].position.x, cornerPoints[1].position.x), Random.Range(cornerPoints[1].position.y, cornerPoints[2].position.y));
        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
    }
}
