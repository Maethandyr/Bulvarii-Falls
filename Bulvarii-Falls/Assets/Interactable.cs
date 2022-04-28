using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;

    private int index;
    private DialogManager dialogManager;
    private AudioSource audioInteract;
    private bool isSentenceComplete;

    private void Start()
    {
        isSentenceComplete = false;
        try
        {
            dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
            audioInteract = GameObject.FindGameObjectWithTag("AudioInteract").GetComponent<AudioSource>();
        }
        catch
        {
            Debug.Log("Hey! You need Dialog Manager or Audio Interact! Look in Prefab!");
        }
        
    }

    void Update ()
    {
        if(textDisplay.text == sentences[index])
        {
            //continueButton.SetActive(true);
            isSentenceComplete = true;
        }

        if (Input.GetKeyDown("space") && isSentenceComplete)
        {
            isSentenceComplete = false;
            NextSentence();
        }
    }

    public void NextSentence()
    {
        //continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            //Resume();
            dialogManager.isDialogTrigger = false;
            index = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e") && dialogManager.isDialogTrigger == false)
        {
            dialogManager.isDialogTrigger = true;
            // Show to player "Press e to continue
            //Pause();
            StartCoroutine(Type());
            audioInteract.Play();
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
} 
