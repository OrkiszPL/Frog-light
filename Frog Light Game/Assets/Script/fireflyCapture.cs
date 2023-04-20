using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireflyCapture : MonoBehaviour
{
    public Transform flyPos;
    public float radius;
    public LayerMask flyLayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Capture()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Collider2D[] flies = Physics2D.OverlapCircleAll(gameObject.transform.position, radius, flyLayer);
            if (flies.Length > 0)
            {
                flyPos = flies[0].transform;
                Vector2 targetDirection = flyPos.position - transform.position;
                float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}
