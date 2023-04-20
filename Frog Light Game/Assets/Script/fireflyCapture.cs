using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireflyCapture : MonoBehaviour
{
    public Transform[] points;
    public GameObject player;
    public PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Capture()
    {
        
    }
}
