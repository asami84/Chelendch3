using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX SpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnScript=GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        enemyRb = GetComponent<Rigidbody>();
        playerGoal=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.tag == "EnemyGoal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.tag == "PlayerGoal")
        {
            SpawnScript.ResetPlayerPosition();
            SpawnScript.waveCount=0;
            Destroy(gameObject);
        }

    }

}
