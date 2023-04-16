using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Variables

    public int HP;

    SwordAttack SwordScript;
    [SerializeField] GameObject Sword;

    private void Awake()
    {
        SwordScript = Sword.GetComponent<SwordAttack>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.transform.tag == "Weapon")
        {
            if (SwordScript.isStabbing == true)
            {
                HP = HP - 50;
            }
        }
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
