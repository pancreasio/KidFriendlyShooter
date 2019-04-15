using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScr : MonoBehaviour
{
    public int maxHitpoints;
    public GameObject gameManager;
    public int hitpoints;
    public int score;
    public float forceMultiplier;
    public float rayDistance;
    public LayerMask rayCastLayer;

    static GameObject characterInstance;


    private void Start()
    {
        characterInstance = this.gameObject;
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
            Vector3 knockDir = new Vector3(collision.transform.position.x - transform.position.x, 0, collision.transform.position.z - transform.position.z);
            transform.GetComponent<Rigidbody>().AddForce(transform.position - knockDir * forceMultiplier, ForceMode.Force);
        }
    }

    private void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(transform.GetChild(0).transform.position, transform.GetChild(0).transform.forward * 20, Color.red);
            if (Physics.Raycast(transform.GetChild(0).transform.position, transform.GetChild(0).transform.forward * 20, out hit, rayDistance, rayCastLayer))
            {
                if (hit.transform.tag == "enemy")
                {
                    Destroy(hit.transform.gameObject);
                    score += hit.transform.GetComponent<EnemyScr>().killScore;
                }
            }
        }

        if (transform.position.y <= -10)
        {
            gameManager.GetComponent<GameManagerScr>().loadEnd();
        }

        if (hitpoints <= 0)
        {
            gameManager.GetComponent<GameManagerScr>().loadEnd();
        }
    }
}
