using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementStop : MonoBehaviour
{

    private Rigidbody2D parentRb;

    private void Start()
    {
        parentRb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentRb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentRb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentRb.velocity = new Vector2(targetDirection.x, targetDirection.y).normalized * Speed;
        }
    }

}
