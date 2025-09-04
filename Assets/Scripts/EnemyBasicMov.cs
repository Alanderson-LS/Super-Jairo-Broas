using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMov : MonoBehaviour
{
    private bool isDeath = false;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Jairo player = other.gameObject.GetComponent<Jairo>();
            
            player.TakeDamage(damage);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            speed = -speed;
        }
    }

}

