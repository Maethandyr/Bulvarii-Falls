using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100;
    [HideInInspector]
    

    private float stamina;
    private Movement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
        playerMovement = gameObject.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        DragonBreath();
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

    IEnumerator StanceCoroutine()
    {
        playerMovement.stance = true;
        Debug.Log("Movement lock");

        //yield on a new YieldInstruction that waits.
        yield return new WaitUntil(() => Input.GetKeyDown("x"));

        playerMovement.stance = false;
        Debug.Log("Movement unlock");
    }
}
