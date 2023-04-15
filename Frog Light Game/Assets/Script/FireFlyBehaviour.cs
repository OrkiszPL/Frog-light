using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyBehaviour : MonoBehaviour
{
    public bool isRight = true;
    public Rigidbody2D rb;
    public bool isUp;
    public bool noMovement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Direction_Left_Right());
        StartCoroutine(Direction_Up_Down());
        StartCoroutine(willMove());
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    IEnumerator Direction_Left_Right()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 3f));
            int leftRight = Random.Range(1, 3);
            if (leftRight == 1)
            {
                isRight = false;

            }
            else if (leftRight == 2 || leftRight == 3)
            {
                isRight = true;
            }
        }
    }

    IEnumerator Direction_Up_Down()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.8f));
            int upDown = Random.Range(1, 3);
            if (upDown == 1)
            {
                isUp = false;
            }
            else if (upDown == 2 || upDown == 3)
            {
                isUp = true;
            }
        }
    }

    IEnumerator willMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            noMovement = true;
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            noMovement = false;
        }
    }

    void Movement()
    {
        if (isRight == true && noMovement == false)
        {
            rb.velocity = new Vector2(Random.Range(0.5f, 1f), rb.velocity.y);
            if (isUp == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, Random.Range(0.5f, 1f));
            }
            if (isUp == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, Random.Range(0.5f, 1f) * -1f);
            }
        }
        else if (isRight == false && noMovement == false)
        {
            rb.velocity = new Vector2(Random.Range(0.5f, 1f) * -1f, rb.velocity.y);
            if (isUp == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, Random.Range(0.5f, 1f));
            }
            if (isUp == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, Random.Range(0.5f, 1f) * -1f);
            }
        }
        else if (noMovement == true)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

}
