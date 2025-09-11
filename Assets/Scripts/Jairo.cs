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
    [SerializeField] private float Jump, Speed;
    [SerializeField] private GameObject Player;
    public GameObject miniJairo;
    private JairoAnimationController anim;
    private SpriteRenderer sr;
    private Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        defaultSprite = sr.sprite;
        canJump = true;
        life = 1;
        anim = GetComponent<JairoAnimationController>();
        miniJairo.SetActive(true);
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

        if (isWalking)
        {
            if (life == 1) 
            {
            anim.PlayAnimation("JairoWalk");
            }
        }
        else
        {
            if (life == 1) 
            {
            anim.PlayAnimation("JairoIdle");
            }
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

        float currentSpeed = Speed;

        if (walkTimer >= 2f) 
        {
            currentSpeed *= 2f;
        }

        if (jumping)
        {
            if (canJump)
            {
                rb.velocity = Vector2.up * Jump;
                canJump = false;
                jumping = false;
            }
        }
        if (walkingRight)
        {
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            walkingRight = false;

            if (transform.localScale.x < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        if (walkingLeft)
        {
            rb.velocity = new Vector2(-currentSpeed, rb.velocity.y);
            walkingLeft = false;
            if (transform.localScale.x > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }

    public void EnableJump() {
        canJump = true;
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

    public void GetLife(){
        life = 2;
    }

}
