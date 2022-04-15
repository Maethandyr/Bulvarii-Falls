using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public int gameOverBuildIndex;
    public bool isPlayerOnScene = false;
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
        /*
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("Press P to restart level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        */
        PlayerIsGone();
    }

    private void PlayerIsGone()
    {
        if (isPlayerOnScene && player == null)
        {
            SceneManager.LoadScene(gameOverBuildIndex);
        }
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene(gameOverBuildIndex);
    }
}
