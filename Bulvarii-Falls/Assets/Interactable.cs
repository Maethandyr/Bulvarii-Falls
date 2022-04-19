using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isGamePaused;
    public GameObject thisIsMyText; //Drop specific memory text here OR
    public TextMeshPro TMP; //here

    public PauseMenu pauseMenu;

    void Update ()
    {
        if (isGamePaused && Input.GetKeyDown("e"))
        {
            pauseMenu.Resume();
            LeaveMeText();
        }
    }
  

    void GiveMeText() 

    {
        Debug.Log("You can talk to rocks now!");
        //TMP.SetActive(true);
    }
    void LeaveMeText()
    {
    //TMP.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
    if (other.CompareTag("Player") && Input.GetKeyDown("e"))
    {
        // Show to player "Press e to continue
        //Pause();
        GiveMeText();
    }
    }
} 
