using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScr : MonoBehaviour
{
    public int maxHitpoints;
    public GameObject gameManager;
    private int hitpoints;
    static GameObject characterInstance;

    private void Start()
    {
        hitpoints = maxHitpoints;
    }

    private void Awake()
    {
        if (this.gameObject != characterInstance && characterInstance != null)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hitpoints -= collision.gameObject.GetComponent<EnemyScr>().damage;
        }
    }

    private void Update()
    {
        if (hitpoints <= 0)
        {
            gameManager.GetComponent<GameManagerScr>().loadEnd();
        }
    }
}
