using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public float currentHealth;
    public float maxHealth = 150f;
    public Image healthBar;
    public healthBar health;
    public GameObject fly;
    public LayerMask flyLayer;
    public float captureRange;

    private void Start()
    {
        currentHealth = maxHealth;
        health = healthBar.GetComponent<healthBar>();
        health.SetMaxHealth(maxHealth);
    }

    public void FixedUpdate()
    {
        //Movement

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + Speed, transform.position.y);

            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - Speed, transform.position.y);

            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
           Collider2D[] flyCol = Physics2D.OverlapCircleAll(transform.position, captureRange, flyLayer);
           if (flyCol.Length != 0)
            {
                fly = flyCol[0].gameObject;
            }
        }


        
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        health.setHealth(currentHealth);

        //Play damage sfx

        if (currentHealth <= 0)
        {
            Debug.Log("Player Died !!!");

            Destroy(gameObject);

            //Play Die Animation

            //Load GameOver Panel
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, captureRange);
    }
}
