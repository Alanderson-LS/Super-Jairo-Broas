using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private int life;
    private SpriteRenderer sr;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Speed, rb.velocity.y);
        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy"))
        {
            Speed = -Speed;
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

