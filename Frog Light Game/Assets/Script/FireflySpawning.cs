using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySpawning : MonoBehaviour
{
    //Variables

    public string tag;
    public GameObject fly;
    public int maxSpawn;
    public GameObject[] flies;
    public Transform[] cornerPoints;

    // Start is called before the first frame update
    void Start()
    {
        flies = new GameObject[maxSpawn];
        StartCoroutine(SpawnFlies());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    //spawning the fireflies
    IEnumerator SpawnFlies()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            //Checking how many objects are there (if there is less than 100 then it will add more fireflies to the scene in random position)
            int currentIndex = 0;
            foreach (GameObject sample in flies)
            {
                if (sample == null)
                {
                    Vector2 SpawnPosition = new Vector2(Random.Range(cornerPoints[0].position.x, cornerPoints[1].position.x), Random.Range(cornerPoints[1].position.y, cornerPoints[2].position.y)); //Generating a random position for spawning the object
                    flies[currentIndex] = Instantiate(fly, SpawnPosition, Quaternion.identity);
                }
                currentIndex++;
            }
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(Random.Range(15f, 30f));

    }
}
