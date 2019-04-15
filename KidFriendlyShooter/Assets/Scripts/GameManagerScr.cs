using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScr : MonoBehaviour
{

    static GameObject managerInstance;

    void Awake()
    {
        if (this.gameObject != managerInstance)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        managerInstance = this.gameObject;
    }

    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
    public void loadGame()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }
    public void loadEnd()
    {
        SceneManager.LoadScene("end", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        exitGame();
    }
}
