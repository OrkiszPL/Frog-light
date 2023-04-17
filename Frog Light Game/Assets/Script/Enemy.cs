using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 300;
    public int currentHP;
    public Transform target;
    public float Speed = 2f;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Target
        if (!target)
        {
            GetTarget();
        }
        else
        {
            Rotation();
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy Died");

        //Play die animation instead of this comment

        //Disable enemy
    }

    public void Rotation()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, 0.025f);
    }

    void Move()
    {
        rb.velocity = transform.up * Speed;
    }

    public void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
