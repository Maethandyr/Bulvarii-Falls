using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 10;
    private float loseStamina = 1;
    [HideInInspector]
    public float stamina = 0;
    public StaminaUI staminaUI;

    private Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
        playerMovement = gameObject.GetComponent<Movement>();
        staminaUI.SetMaxEnergy(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        DragonBreath();
        staminaUI.SetEnergy(stamina);
    }

    private void FixedUpdate()
    {
        
    }

    private void DragonBreath()
    {
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("Dragon Breath Stance");
            stamina = maxStamina;
            StartCoroutine(StanceCoroutine());
        }
    }

    private void Test()
    {
        if (Input.GetKeyDown("space") && stamina <= maxStamina)
        {
            stamina -= loseStamina;
            staminaUI.SetEnergy(stamina);
            Debug.Log("Stamina: " + stamina);
        }
    }

    public IEnumerator StanceCoroutine()
    {
        playerMovement.stance = true;
        Debug.Log("Movement lock");

        //yield on a new YieldInstruction that waits.
        yield return new WaitUntil(() => stamina >= 0);

        playerMovement.stance = false;
        Debug.Log("Movement unlock");
    }
}
