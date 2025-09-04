using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jairo : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canJump;
    private bool jumping, walkingRight, walkingLeft;
    private int life;
    private float walkTimer = 0f;
    private bool isWalking = false;
    [SerializeField] private float jump, speed;
    [SerializeField] private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            walkingRight = true;
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            walkingLeft = true;
            isWalking = true;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            isWalking = false;
            walkTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            walkTimer += Time.fixedDeltaTime;
        } else {
            walkTimer = 0f;
        }

        float currentSpeed = speed;

        if (walkTimer >= 2f) 
        {
            currentSpeed *= 2f;
        }

        if (jumping)
        {
            if (canJump)
            {
                rb.velocity = Vector2.up * jump;
                canJump = false;
                jumping = false;
            }
        }
        if (walkingRight)
        {
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            walkingRight = false;
        }
        if (walkingLeft)
        {
            rb.velocity = new Vector2(-currentSpeed, rb.velocity.y);
            walkingLeft = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void Kill()
    {
        Destroy(Player);
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
