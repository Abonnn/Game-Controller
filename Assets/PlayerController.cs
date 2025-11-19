using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Pengaturan Jalur (Lanes)")]
    public float laneChangeSpeed = 10f;
    public float[] laneYPositions;

    [Header("Pengaturan Menembak")]
    public GameObject peluruPrefab;
    public Transform titikTembak;

    private int maxHealth = 100;
    public int health = 100;
    public GameOver gameOver;
    public HealthBar healthBar;

    private int currentLane = 1;

    void Start()
    {
        transform.position = new Vector2(transform.position.x, laneYPositions[currentLane]);

        health = maxHealth;
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }
    }

    void Update()
    {
        HandleInput();
        MoveToLane();
    }
    private void HandleInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKeyDown(KeyCode.UpArrow) && currentLane < laneYPositions.Length - 1)
        {
            currentLane++;
            Debug.Log("Pindah ke atas (Keyboard). Lane sekarang: " + currentLane);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentLane > 0)
        {
            currentLane--;
            Debug.Log("Pindah ke bawah (Keyboard). Lane sekarang: " + currentLane);
        }

        else if (scroll > 0.01f && currentLane < laneYPositions.Length - 1) 
        {
            currentLane++;
            
            Debug.Log("Pindah ke atas (Scroll). Lane sekarang: " + currentLane);
        }
        else if (scroll < -0.01f && currentLane > 0) 
        {
            currentLane--;
            Debug.Log("Pindah ke bawah (Scroll). Lane sekarang: " + currentLane);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Shoot()
    {
        Instantiate(peluruPrefab, titikTembak.position, titikTembak.rotation);
    }

    private void MoveToLane()
    {
        float targetY = laneYPositions[currentLane];
        Vector2 targetPosition = new Vector2(transform.position.x, targetY);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
    }

    private void Die()
    {
        if (gameOver != null)

        {

            gameOver.EnableGameOverMenu();

        }
        Destroy(gameObject);
    }

    // Penting: Tambahkan fungsi OnTriggerEnter2D jika belum ada
    // agar player bisa menerima damage dari rintangan.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Tentukan jumlah damage saat menabrak
            TakeDamage(25);

            // Hancurkan rintangan setelah ditabrak
            Destroy(other.gameObject);
        }
    }
}