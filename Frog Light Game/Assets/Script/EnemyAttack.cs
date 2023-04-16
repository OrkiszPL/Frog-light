using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyScript script;
    [SerializeField] GameObject enemy;

    public Animator anim;

    private void Awake()
    {
        script = enemy.GetComponent<EnemyScript>();
        anim = enemy.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.Speed = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.Speed = 0f;
            anim.SetTrigger("Animatable");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.Speed = 0.1f;
        }
    }
}
