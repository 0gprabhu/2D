using UnityEngine;
using UnityEngine.UI;
using TMPro; // This allows us to use TextMeshPro

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4.5f;
    public float maxY = 4.5f;

    public int maxHealth = 5;
    private int currentHealth;

    public Slider healthBar;
    public Image fillImage; // Reference to the Fill image
    public TextMeshProUGUI gameOverText; // Reference to the Game Over text

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        UpdateHealthBarColor();
        gameOverText.gameObject.SetActive(false); // Make sure Game Over text is hidden at the start
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(clampedX, clampedY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth--;
            healthBar.value = currentHealth;
            UpdateHealthBarColor();

            Destroy(collision.gameObject);

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateHealthBarColor()
    {
        if (currentHealth > maxHealth / 2)
        {
            fillImage.color = Color.green; // Healthy color
        }
        else if (currentHealth > maxHealth / 4)
        {
            fillImage.color = Color.yellow; // Warning color
        }
        else
        {
            fillImage.color = Color.red; // Danger color
        }
    }

    void GameOver()
    {
        Debug.Log("Player Died");
        Destroy(gameObject);
        gameOverText.gameObject.SetActive(true); // Show the Game Over text
    }
}
