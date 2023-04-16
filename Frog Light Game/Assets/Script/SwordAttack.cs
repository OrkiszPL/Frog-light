using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    // Variables

    private Animator Ani;

    private float Cooldown;
    public bool isStabbing;

    void Start()
    {
        // Assigns Animator to the Variable
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        
        if(Cooldown <= Time.time)
        {
            // When mouse is clicked activate Attack Amination and starts a cooldown
            if(Input.GetMouseButtonDown(0))
            {
                Ani.SetTrigger("LeftClickTrigger");
                Cooldown = Time.time + 0.3f;
                
                // Start the damage function
                StartCoroutine(DealDamage());
            }
        }
    }

    IEnumerator DealDamage()
    {
        isStabbing = true;
        yield return new WaitForSeconds(0.1f);
        isStabbing = false;
    }

}
