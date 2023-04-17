using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementStop : MonoBehaviour
{
    EnemyScript script;

    public GameObject enemy;
    float initialSpeed;

    private void Start()
    {
        script = enemy.GetComponent<EnemyScript>();
        initialSpeed = script.Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script.Movement(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script.Movement(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script.Movement(true);
        }
    }

}
