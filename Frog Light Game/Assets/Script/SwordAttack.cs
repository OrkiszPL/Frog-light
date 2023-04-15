using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    // Variables

    private Animator Ani;

    private double Cooldown;

    void Start()
    {
        // Assigns Animator to the Variable
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(Cooldown <= Time.time)
        {
            // When mouse is clicked activate Attack Amination
            if(Input.GetMouseButtonDown(0))
            {
                Ani.SetTrigger("LeftClickTrigger");
                Cooldown = Time.time + 0.5;
            }
        }
    }
}
