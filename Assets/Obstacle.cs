using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 10;
    public int health = 100;
    public float moveSpeed = 5f;
    private float leftBound = -10f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
        }
    }

    private void Die()
    {
        GameManager.instance.AddKill();
        Destroy(gameObject);
    }
}