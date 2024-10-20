using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIFast : EnemyAI
{


    // Start is called before the first frame update

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
            transform.position += direction * 12 * Time.deltaTime;
            if (direction.magnitude >= 1.5f)
            {
                Debug.LogWarning("Something went wrong with enemy AI movement!");
            }
        }
    }
}
