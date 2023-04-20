using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject objectPrefab; // the object to spawn
    public int numObjects = 5; // the number of objects to spawn
    public float spawnRadius = 5f; // radius around the camera where objects can spawn

    private List<GameObject> spawnedObjects; // a list of the spawned objects

    void Start()
    {
        spawnedObjects = new List<GameObject>();

        // spawn the objects initially
        for (int i = 0; i < numObjects; i++)
        {
            SpawnObject();
        }
    }

    void Update()
    {
        // check if any objects are missing
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
                // respawn the missing object
                SpawnObject();
            }
        }
    }

    void SpawnObject()
    {
        // get the camera position and direction
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 cameraDir = Camera.main.transform.forward;

        // generate a random position within the spawn radius
        Vector3 spawnPos = cameraPos + Random.insideUnitSphere * spawnRadius;

        // calculate the dot product of the camera direction and spawn position
        float dot = Vector3.Dot(spawnPos - cameraPos, cameraDir);

        // if the dot product is negative, the object is behind the camera
        if (dot < 0)
        {
            // try again with a new position
            SpawnObject();
            return;
        }

        // spawn the object
        GameObject obj = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
        spawnedObjects.Add(obj);
    }

    void OnDestroy()
    {
        if (spawnedObjects.Contains(gameObject))
        {
            spawnedObjects.Remove(gameObject);
        }
    }
}
