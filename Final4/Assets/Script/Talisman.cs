using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman : MonoBehaviour
{
    [SerializeField] private float firespeed, lifetime;
    [SerializeField] public int Pdirection;
    [SerializeField] private Rigidbody2D rb;

    public static Talisman instance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Pdirection = Player.instance.direction;

        if(Pdirection == -1)
        {
            transform.localScale = new Vector2(-1,1f);
        }
        else
        {
            transform.localScale = new Vector2(1, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(firespeed * Pdirection, rb.velocity.y);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Player.instance.Recharge(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            Player.instance.Recharge(1);
            Destroy(gameObject);
        }
    }

    public void Talismanhit()
    {
        Player.instance.Recharge(1);
        Destroy(gameObject);
    }
}
