 using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy
    public Transform player;  // Reference to the player transform

    void Start()
    {
        // Find the player GameObject with the "Player" tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }


    void Update()
    {
        if (player != null)
        {
            // Calculate the direction to the player
            Vector2 direction = (player.position - transform.position).normalized;
            // Move the enemy towards the player
            transform.Translate(direction * speed * Time.deltaTime);
        }

        // Destroy the enemy if it goes off the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
