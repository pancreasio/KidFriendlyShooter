using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScr : MonoBehaviour
{
    public GameManagerScr gameManager;
    public Text score;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManagerScr>();
    }
    void Update()
    {
        score.text = gameManager.GetComponent<GameManagerScr>().score.ToString();
    }
}
