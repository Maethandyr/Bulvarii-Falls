using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallInteraction : MonoBehaviour
{
    public float gainStamina = 10;
    public bool canUpgrade = true;
    public AudioSource audioSourceWaterfall;
    public AudioSource audioSourceHeartbeat;

    private GameObject player;
    private StaminaUI staminaUI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        staminaUI = player.GetComponentInChildren<StaminaUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSourceWaterfall.Play();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e") && canUpgrade)
        {
            canUpgrade = false;
            staminaUI.GainMaxStamina(gainStamina); // Gain stamina
            audioSourceHeartbeat.Play();
        }
        else if (other.CompareTag("Player") && Input.GetKey("e") && canUpgrade == false)
        {
            staminaUI.RefillEnergy(); // Refill stamina
            audioSourceHeartbeat.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSourceWaterfall.Stop();
        }
    }
}
