using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    // Variables

    public Rigidbody2D rb; 

    void Update()
    {
        // When mouse is clicked write "Sword Swing"
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Sword Swing");
        }
    }
}
