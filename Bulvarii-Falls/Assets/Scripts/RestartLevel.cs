using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public int sceneBuildIndex;
    public int gameOverBuildIndex;
    public bool isPlayerOnScene = false;
    public float timer = 5;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayerOnScene)
        {
            try
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            catch
            {
                Debug.Log("Hey! There is no player on scene!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("Press P to restart level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //PlayerIsGone();
    }

    private void PlayerIsGone()
    {
        if (isPlayerOnScene && player == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene(gameOverBuildIndex);
    }
}
