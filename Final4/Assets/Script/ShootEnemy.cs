using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] public int direction;
    [SerializeField] private Rigidbody2D rb;

    public static ShootEnemy instance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            FilpSprite();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground") && !collision.CompareTag("Player"))
        {
            FilpSprite();
        }
    }
    void FilpSprite()
    {
        if (direction == 1)
        {
            direction = -1;
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            direction = 1;
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
