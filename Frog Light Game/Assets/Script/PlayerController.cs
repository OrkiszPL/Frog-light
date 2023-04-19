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

    private void Start()
    {
        currentHealth = maxHealth;
        health = healthBar.GetComponent<healthBar>();
        health.SetMaxHealth(maxHealth);
    }

    void FixedUpdate()
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
}
