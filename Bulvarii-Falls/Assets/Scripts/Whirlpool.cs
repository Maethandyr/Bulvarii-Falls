using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    private Movement playerMovement;
    private Stamina stamina;
    public StaminaUI staminaUI;

    // Start is called before the first frame update
    void Start()
    {
        //Player Gameobject with script Movement
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        stamina = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>();
        staminaUI = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<StaminaUI>();
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
            staminaUI.SetEnergy(0);
            StartCoroutine(stamina.StanceCoroutine());
            playerMovement.whirlpoolRotating = true;
        }
    }
}
