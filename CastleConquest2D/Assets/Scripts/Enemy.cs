using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyRunSpeed = 5f;

    Rigidbody2D enemyRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingLeft())
        { 
            enemyRigidbody.velocity = new Vector2(-enemyRunSpeed, 0f);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(enemyRunSpeed, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(enemyRigidbody.velocity.x), 1f);
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x > 0;
    }
}
