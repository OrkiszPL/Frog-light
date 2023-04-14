using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    // Variables
    public Camera cam;
    Vector2 MousePos;

    public Rigidbody2D rb;
    public Transform Player;

    // Checking position of the mouse
    void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Do some math sh*t to rotate the sword according to the mouse position
    void FixedUpdate()
    {
        Vector2 rotation = MousePos - rb.position;

        float Angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if(Player.position == transform.position)
            rb.rotation = Angle;
    }
}
