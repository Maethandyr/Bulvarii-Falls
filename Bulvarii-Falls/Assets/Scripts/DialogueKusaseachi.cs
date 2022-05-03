using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueKusaseachi : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public string[] sentences;

    public float typingSpeed = 0.02f;

    [HideInInspector]
    public bool isRock1 = false;
    [HideInInspector]
    public bool isRock2 = false;
    [HideInInspector]
    public bool isRock3 = false;
    [HideInInspector]
    public bool isRock4 = false;
    [HideInInspector]
    public bool isWood1 = false;
    [HideInInspector]
    public bool isWood2 = false;
    [HideInInspector]
    public bool isWood3 = false;
    [HideInInspector]
    public bool isWood4 = false;
    [HideInInspector]
    public bool isFlower1 = false;
    [HideInInspector]
    public bool isFlower2 = false;
    [HideInInspector]
    public bool isFlower3 = false;
    [HideInInspector]
    public bool isFlower4 = false;

    private int index;
    private bool isSentenceComplete;
    private DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        isRock1 = false;
        isRock2 = false;
        isRock3 = false;
        isRock4 = false;
        isWood1 = false;
        isWood2 = false;
        isWood3 = false;
        isWood4 = false;
        isFlower1 = false;
        isFlower2 = false;
        isFlower3 = false;
        isFlower4 = false;

        try
        {
            dialogManager = GameObject.FindGameObjectWithTag("DialogManager").GetComponent<DialogManager>();
        }
        catch
        {
            Debug.Log("Hey! You need Dialog Manager! Look in Prefab!");
        }
        if (textDisplay == null)
        {
            Debug.Log("Hey! You need Text Display!, look in Pause Menu for Text Display and drag and drop!");
        }
        if (sentences.Length < 12)
        {
            Debug.Log("Hey! You need total of 12 sentences!");
        }
        isSentenceComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            //continueButton.SetActive(true);
            isSentenceComplete = true;
        }

        if (Input.GetKeyDown("space") && isSentenceComplete)
        {
            isSentenceComplete = false;
            //NextSentence();
            textDisplay.text = ""; // Erase Text
        }
    }
    public void NextSentence()
    {
        //continueButton.SetActive(false);

        if (index < sentences.Length - 1)
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
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e") && dialogManager.isDialogTrigger == false)
        {
            dialogManager.isDialogTrigger = true;
            
            if (isRock1)
            {
                index = 0;
                StartCoroutine(Type());
            }
            else if (isRock2)
            {
                index = 1;
                StartCoroutine(Type());
            }
            else if (isRock3)
            {
                index = 2;
                StartCoroutine(Type());
            }
            else if (isRock4)
            {
                index = 3;
                StartCoroutine(Type());
            }
            else if (isWood1)
            {
                index = 4;
                StartCoroutine(Type());
            }
            else if (isWood2)
            {
                index = 5;
                StartCoroutine(Type());
            }
            else if (isWood3)
            {
                index = 6;
                StartCoroutine(Type());
            }
            else if (isWood4)
            {
                index = 7;
                StartCoroutine(Type());
            }
            else if (isFlower1)
            {
                index = 8;
                StartCoroutine(Type());
            }
            else if (isFlower2)
            {
                index = 9;
                StartCoroutine(Type());
            }
            else if (isFlower3)
            {
                index = 10;
                StartCoroutine(Type());
            }
            else if (isFlower4)
            {
                index = 11;
                StartCoroutine(Type());
            }
        }
    }
}
