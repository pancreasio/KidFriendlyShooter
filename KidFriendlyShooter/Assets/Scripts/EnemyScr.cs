using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    public int maxHitpoints;
    public int damage;
    public int killScore;

    private int hitpoints;

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.position.y >= 6)
        {
            Destroy(this.gameObject);
        }
    }
}
