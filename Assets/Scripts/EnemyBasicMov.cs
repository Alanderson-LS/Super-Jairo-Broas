using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMov : MonoBehaviour
{
    private bool isDeath = false;
    private Rigidbody2D rb;
    private int life;
    [SerializeField] private float speed;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!isDeath)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Jairo player = other.gameObject.GetComponent<Jairo>();
                player.TakeDamage(damage);
            }
            if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy"))
            {
                speed = -speed;
            }
        }
    }

    private void Kill()
    {
        Destroy(enemy);
    }


    public void TakeDamage(int amount)
    {
        life -= amount;
        if (life <= 0)
        {
            Kill();
        }
    }


}

