using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    private Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        //Player Gameobject with script Movement
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player is dead");
            playerMovement.whirlpoolRotating = true;
        }
    }
}
