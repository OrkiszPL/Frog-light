using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Variables

    public Transform target;
    public int maxHP;
    int currentHP;
    public float Speed;
    public Rigidbody2D rb;

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        RotateTowardsTarget();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void RotateTowardsTarget()
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

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
