using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySpawning : MonoBehaviour
{
    public GameObject objectPrefab; // The object to spawn
    public int numObjects = 25; // Number of objects to spawn
    public Vector2 spawnArea = new Vector2(10f, 10f); // The area within which objects will be spawned
    public float respawnTime = 2f; // Time in seconds before a new object is respawned after destruction

    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to keep track of spawned objects

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numObjects; i++)
        {
            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y));
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
        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y));
        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
    }
}
