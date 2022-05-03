using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed = 0.02f;

    private int index;
    private DialogManager dialogManager;
    private AudioSource audioInteract;
    private DialogueKusaseachi kusaseachi;
    private bool isSentenceComplete;
    private bool isKusaseachiMessageSent;

    private void Start()
    {
        isSentenceComplete = false;
        try
        {
            dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
            audioInteract = GameObject.FindGameObjectWithTag("AudioInteract").GetComponent<AudioSource>();
            kusaseachi = GameObject.FindGameObjectWithTag("kusaseachi").GetComponent<DialogueKusaseachi>();
        }
        catch
        {
            Debug.Log("Hey! You need Dialog Manager, Audio Interact or Kusaseachi with DialogueKusaseachi script! Look in Prefab!");
        }
        
        if (textDisplay == null)
        {
            Debug.Log("Hey! You need Text Display!, look in Pause Menu for Text Display and drag and drop!");
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

            if (isKusaseachiMessageSent == false) // should only activate once for object interaction if case is true
            {
                switch (gameObject.tag) // If the case is true, it should only activate once
                {
                    case "Rock1":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isRock1 = true;
                        break;
                    case "Rock2":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isRock2 = true;
                        break;
                    case "Rock3":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isRock3 = true;
                        break;
                    case "Rock4":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isRock4 = true;
                        break;
                    case "Wood1":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isWood1 = true;
                        break;
                    case "Wood2":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isWood2 = true;
                        break;
                    case "Wood3":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isWood3 = true;
                        break;
                    case "Wood4":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isWood4 = true;
                        break;
                    case "Flower1":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isFlower1 = true;
                        break;
                    case "Flower2":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isFlower2 = true;
                        break;
                    case "Flower3":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isFlower3 = true;
                        break;
                    case "Flower4":
                        isKusaseachiMessageSent = true;
                        kusaseachi.isFlower4 = true;
                        break;
                }
            }
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
