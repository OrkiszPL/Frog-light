using System.Collections;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    // Variables

    public Animator Ani;

    [SerializeField] GameObject enemyObject;
    public bool isStabbing;
    public GameObject Blood;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    [SerializeField] private int damage = 50;

    void Update()
    {
            // When mouse is clicked activate Attack Amination and starts a cooldown
            if(Input.GetMouseButtonDown(0))
            {
                Attack();
            }
    }


    void Attack()
    {
            Ani.SetTrigger("LeftClickTrigger");

            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D enemyCol in enemies)
            {
                enemyCol.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            }

    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
