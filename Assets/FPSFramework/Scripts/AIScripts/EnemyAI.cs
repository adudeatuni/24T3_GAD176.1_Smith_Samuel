using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected Transform player;
    protected float myMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();

        myMoveSpeed = 6;
    }

    // Update is called once per frame
    void Update()
    {
            moveTowardsPlayer();
    }

    private void moveTowardsPlayer()
    {
        if (player == null)
        {
            Debug.LogWarning("Something went wrong finding the player object! Check if they have been given a tag of 'Player'!");
            return;
        }
        else
        {
            Vector3 direction = (player.transform.position - transform.position);
            direction = direction.normalized;
            transform.position += direction * myMoveSpeed * Time.deltaTime;
            if (direction.magnitude >= 1.5f)
            {
                Debug.LogWarning("Something went wrong with enemy AI movement!");
            }
        }
    }


    public 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(" " + other.gameObject.name + " was hit by " + transform.name);
        Destroy(gameObject);
    }
}
