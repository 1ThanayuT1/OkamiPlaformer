using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] private int direction;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Animator bossanime;

    public int bossshield = 2;
    [SerializeField] private GameObject hitPoint;

    [SerializeField] private bool ismove;
    public static Boss instance;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bossanime = GetComponent<Animator>();
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.hp != 0)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            ismove = (speed * direction != 0);
            BossAnimate();
        }

        if (bossshield == 0)
        {
            hitPoint.SetActive(true);
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
        if (!collision.CompareTag("Ground") && !collision.CompareTag("Player") && !collision.CompareTag("Talisman"))
        {
            FilpSprite();
        }
        if (bossshield != 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Player.instance.instantKill(3);
            }
        }

        if (collision.gameObject.tag == "Talisman")
        {
            bossshield--;
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

    public void ShieldRestore()
    {
        if (BossFight.instance.bossHP != 0)
        {
            hitPoint.SetActive(false);
            bossshield = 2;
        }
    }

    void BossAnimate()
    {
        bossanime.SetBool("isMove", ismove);
    }

    public void BossDie()
    {
        BossStart.instance.BossSilence();
        Destroy(gameObject);

        if (Gameplay.instance.ball == 1 && Gameplay.instance.omamori == 1)
        {
            EndVideo.instance.Ending3();
        }
        else if (Gameplay.instance.ball == 1 || Gameplay.instance.omamori == 1)
        {
            EndVideo.instance.Ending2();
        }
        else
        {
            EndVideo.instance.Ending1();
        }
    }
}
