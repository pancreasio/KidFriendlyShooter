using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScr : MonoBehaviour
{

    public GameObject player;
    public Text score;
    void Update()
    {
        score.text = player.GetComponent<CharacterScr>().score.ToString();
    }
}
