using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float enemyMoveSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
        moveTowardsPlayer();
        }
    }

    void moveTowardsPlayer()
    {
        if (player == null)
        {
            Debug.LogWarning("Something went wrong finding the player object! Check if they have been given a tag of 'Player'!");
            return;
        }
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction;
        transform.position += direction * enemyMoveSpeed * Time.deltaTime;
        if (direction.magnitude >= 1.5f)
        {
            Debug.LogWarning("Something went wrong with enemy AI movement!");
        }
    }
}
