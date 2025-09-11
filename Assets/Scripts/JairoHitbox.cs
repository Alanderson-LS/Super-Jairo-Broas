using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JairoHitbox : MonoBehaviour
{
    public string parte;
    public Jairo player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.GetComponent<Jairo>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ESSAPORRAFUNCIONA");
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (parte == "body" || parte == "head")
            {
                player.TakeDamage(1);
            }
            if (parte == "foot")
            {
                EnemyBasicMov Enemy = other.gameObject.GetComponent<EnemyBasicMov>();
                Enemy.TakeDamage(1);
            }
        }
        if (other.gameObject.CompareTag("Ground") && parte == "foot")
        {
            player.EnableJump();
        } 
    }
}
