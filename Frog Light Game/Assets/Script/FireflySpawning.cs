using UnityEngine;

public class FireflySpawning : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDelay = 1f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnObject", 0f, spawnDelay);
    }

    void SpawnObject()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(mainCamera.ViewportToWorldPoint(Vector2.zero).x, mainCamera.ViewportToWorldPoint(Vector2.one).x),
            Random.Range(mainCamera.ViewportToWorldPoint(Vector2.zero).y, mainCamera.ViewportToWorldPoint(Vector2.one).y)
        );

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}
