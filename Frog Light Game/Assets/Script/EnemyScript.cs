using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Variables

    public int HP;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.transform.tag == "Weapon")
        {
            HP = HP - 50;
        }
    }
}
