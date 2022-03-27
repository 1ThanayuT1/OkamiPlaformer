using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] private int direction;
    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.hp != 0)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        }
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

        if (collision.gameObject.tag == "Talisman")
        {
            Destroy(gameObject);
            Talisman.instance.Talismanhit();
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
