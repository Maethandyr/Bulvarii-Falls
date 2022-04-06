using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100;
    public float gainStamina = 10;
    public StaminaUI staminaUI;
    public float stamina = 0;

    private Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        stamina = 0;
        playerMovement = gameObject.GetComponent<Movement>();
        staminaUI.SetMaxEnergy(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        DragonBreath();
        if (Input.GetKeyDown("space") && stamina < maxStamina)
        {
            stamina += gainStamina;
            staminaUI.SetEnergy(stamina);
            Debug.Log("Stamina: " + stamina);
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void DragonBreath()
    {
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("Dragon Breath Stance");
            stamina = 0;
            StartCoroutine(StanceCoroutine());
        }
    }

    public IEnumerator StanceCoroutine()
    {
        playerMovement.stance = true;
        Debug.Log("Movement lock");

        //yield on a new YieldInstruction that waits.
        yield return new WaitUntil(() => stamina >= maxStamina);

        playerMovement.stance = false;
        Debug.Log("Movement unlock");
    }
}
