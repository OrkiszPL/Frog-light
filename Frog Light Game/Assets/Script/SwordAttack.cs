using System.Collections;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    // Variables

    public Animator Ani;

    /*EnemyScript enemy;*/

    [SerializeField] GameObject enemyObject;
    private float Cooldown;
    public bool isStabbing;
    public GameObject Blood;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    [SerializeField] private int damage = 50;

    private void Awake()
    {
       /* enemy = enemyObject.GetComponent<EnemyScript>();*/
    }
    void Start()
    {

    }

    void Update()
    {
            // When mouse is clicked activate Attack Amination and starts a cooldown
            if(Input.GetMouseButtonDown(0))
            {
                Attack();
            }
    }

/*    IEnumerator DealDamage()
    {
        isStabbing = true;
        yield return new WaitForSeconds(0.1f);
        isStabbing = false;
    }*/

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (isStabbing == true)
            {
                enemy.HP = enemy.HP - 50;
                GameObject reference = Instantiate(Blood, enemyObject.transform.position, enemyObject.transform.rotation);
                Destroy(reference, 0.5f);
            }
        }
    }*/

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
