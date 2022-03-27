using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private float movespeed, lifetime;
    [SerializeField] private int Bdirection;
    [SerializeField] private Rigidbody2D rb;

    public static BulletControl instance;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent < Rigidbody2D>();
        instance = this;
    }
    void Start()
    {
        Bdirection = ShootEnemy.instance.direction;

        if (Bdirection == -1)
        {
            transform.localScale = new Vector2(-1, 1f);
        }
        else
        {
            transform.localScale = new Vector2(1, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(movespeed * Bdirection, rb.velocity.y);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
    public void BullethitPlayer()
    {
        Destroy(gameObject);
    }
}
