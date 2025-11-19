using UnityEngine;

public class PeluruController : MonoBehaviour
{
    public int damage = 10;
    public float speed = 20f; 
    private float rightBound = 12f; 

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            if(obstacle != null)
            {
                obstacle.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}