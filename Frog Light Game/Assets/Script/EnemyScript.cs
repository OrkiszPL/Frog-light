using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHP = 300;
    public int currentHP;
    public float Speed = 2f;
    public float rotSpeed = 0.0025f;
    public Rigidbody2D rb;
    public Transform target;
    public float circleRange;
    public LayerMask targetLayer;
    public Transform circle;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        StartCoroutine(DamageDealer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
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

    void Movement()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, rotSpeed);
        rb.velocity = new Vector2(targetDirection.x, targetDirection.y).normalized * Speed;
    }

    void DealDamage(float deal)
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(circle.position, circleRange, targetLayer);
        foreach (Collider2D p in player)
        {
            p.GetComponent<PlayerController>().Damage(deal);

            //Play Attack Animation
        }
    }

    IEnumerator DamageDealer()
    {
        while (true)
        {
            DealDamage(Random.Range(5f, 10f));
            yield return new WaitForSeconds(0.5f);
            DealDamage(0f);
        }
    }
}
