using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public int deathQuoteBuiltIndex;
    public int nextSceneBuiltIndex;
    public float timer = 5;

    private int SceneIndex;
    
    private void Start()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        switch (SceneIndex)
        {
            case 0:
                break;
            case 1:
                //This is the Main Cenote Scene
                break;
            case 2:
                //This is the Death Quote Scene
                if (timer <= 0)
                {
                    StartCoroutine(LoadLevel(nextSceneBuiltIndex)); 
                }
                timer -= Time.deltaTime;
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                Debug.Log("You've entered Hell, wtf are you doing here?");
                break;

        }
        
        //Right click to Scene Transiton for Testing Purposes
        
        /*

            if (Input.GetMouseButtonDown(1))
        {
            LoadNextLevel();
        }
        */


    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 > 5)
        {
            SceneManager.LoadScene(0);


        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        }
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    public void DeathQuoteScene()
    {
        StartCoroutine(LoadLevel(deathQuoteBuiltIndex));
    }


}
