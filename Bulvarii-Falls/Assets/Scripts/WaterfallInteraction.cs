using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallInteraction : MonoBehaviour
{
    public float gainStamina = 10;
    public bool canUpgrade = true;

    private AudioSource audioSource;
    private GameObject player;
    private StaminaUI staminaUI;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        staminaUI = player.GetComponentInChildren<StaminaUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e") && canUpgrade)
        {
            canUpgrade = false;
            staminaUI.GainMaxStamina(gainStamina); // Gain stamina
            audioSource.Play();
        }
        else if (other.CompareTag("Player") && Input.GetKey("e") && canUpgrade == false)
        {
            staminaUI.RefillEnergy(); // Refill stamina
            audioSource.Play();
        }
    }
}
