using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Variables

    public float speed = 3f;
    public Transform target;
    public int HP;
    public float Speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        RotateTowardsTarget();
        rb.velocity = transform.up * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, 0.025f);
    }
}
