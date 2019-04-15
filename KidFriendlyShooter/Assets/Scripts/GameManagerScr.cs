using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScr : MonoBehaviour
{

    static GameObject managerInstance;
    public GameObject[] templateArray;
    public GameObject player;
    public GameObject UIstuff;

    private GameObject[,] terrainArray = new GameObject[5,5];
    private bool levelGenerated = false;

    void Awake()
    {
        if (this.gameObject != managerInstance && managerInstance != null)
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
        levelGenerated = false;
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }
    public void loadEnd()
    {
        SceneManager.LoadScene("end", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "game")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            if (!levelGenerated)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int i0 = 0; i0 < 5; i0++)
                    {
                        int randomNumber = Random.Range(0,8);
                        //switch (randomNumber)
                        //{
                        //    case 0:
                        //        randomNumber = Random.Range(0, 3);
                        //        break;
                        //    case 1:
                        //        randomNumber = Random.Range(0, 3);
                        //        break;
                        //    case 2:
                        //        randomNumber = Random.Range(0, 3);
                        //        break;
                        //    case 3:
                        //        randomNumber = Random.Range(0, 3);
                        //        break;
                        //    case 4:
                        //        randomNumber = Random.Range(0, 3);
                        //        break;
                        //    case 5:
                        //        randomNumber = Random.Range(0, 3);
                        //        break;
                        //    case 6:
                        //        randomNumber = Random.Range(4, 6);
                        //        break;
                        //    case 7:
                        //        randomNumber = Random.Range(4, 6);
                        //        break;
                        //    case 8:
                        //        randomNumber = Random.Range(4, 6);
                        //        break;
                        //    case 9:
                        //        randomNumber = Random.Range(7, 8);
                        //        break;
                        //}
                        Debug.Log(randomNumber);
                        terrainArray[i, i0] = Instantiate(templateArray[randomNumber],new Vector3(i*20,0,i0*20), Quaternion.identity);
                    }
                }
                int randomNumber0 = Random.Range(0, 5);
                int randomNumber1 = Random.Range(0, 5);

                GameObject newPlayer = Instantiate(player, terrainArray[randomNumber0, randomNumber1].transform.GetChild(0).transform.position, Quaternion.Euler(0, 0, 0));
                newPlayer.GetComponent<CharacterScr>().gameManager = this.gameObject;
                GameObject newUI = Instantiate(UIstuff);
                newUI.transform.GetChild(0).GetComponent<HPUIScr>().player = newPlayer;
                newUI.transform.GetChild(1).GetComponent<ScoreScr>().player = newPlayer;
                levelGenerated = true;
            }
        }
    }
}