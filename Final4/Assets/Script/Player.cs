using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    public int hp = 3;
    public int direction;
    public int cooldown = 1;
    private bool isFlash = false;
    [SerializeField] public bool Djumpcheck;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private bool isGround;
    [SerializeField] private bool isMove;
    [SerializeField] private bool isAttack;
    [SerializeField] private bool isDie;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator anime;
    [SerializeField] SpriteRenderer sr;

    public static Player instance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FilpSprite();
        CheckGround();
        AnimePlayer();
        FireTalisman();
        TurnFirePoint();
    }

    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        isMove = (Input.GetAxisRaw("Horizontal") != 0);
    }

    void FilpSprite()
    {
        bool filp = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (filp)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(transform.position, 0.75f, groundLayer);
        if (isGround = Physics2D.OverlapCircle(transform.position, 0.75f, groundLayer))
        {
            Djumpcheck = true;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround && !isFlash)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            AudioManager.instance.playJump();
        }
        if (Input.GetButtonDown("Jump") && !isGround && Djumpcheck == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            AudioManager.instance.playJump();
            Djumpcheck = false;
        }
    }

    void AnimePlayer()
    {
        anime.SetBool("isMove", isMove);
        anime.SetBool("isGround", isGround);
        anime.SetBool("isAttack", isAttack);
        anime.SetBool("isDie", isDie);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isFlash)
        {
            getdamage();
        }

        if (collision.gameObject.tag == "Bullet" && !isFlash)
        {
            getdamage();
            BulletControl.instance.BullethitPlayer();
        }
    }
    void getdamage()
    {
        hp--;

        if (hp >= 1)
        {
            isFlash = true;
            rb.bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Flash());
        }

        if (hp <= 0)
        {
            isDie = hp == 0;
            AudioManager.instance.playGhost();
            StartCoroutine(delaydie());
        }
    }

    void FireTalisman()
    {
        if (Input.GetKeyDown(KeyCode.F) && Gameplay.instance.coin > 0 && cooldown == 1)
        {
            AudioManager.instance.playItem();
            TalismanFire.instance.FireTalisman();
            Gameplay.instance.UseTalisman();
            cooldown--;
        }
        isAttack = Input.GetKeyDown(KeyCode.F);
    }
    void TurnFirePoint()
    {
        if (Mathf.Sign(rb.velocity.x) > 0)
        {
            direction = 1;
        }
        else if(Mathf.Sign(rb.velocity.x) < 0)
        {
            direction = -1;
        }
    }

    public void instantKill(int hpdeplete)
    {
        hp -= hpdeplete;
        isDie = hp == 0;
        AudioManager.instance.playGhost();
        StartCoroutine(delaydie());
    }
    public void Recharge(int recharge)
    {
        cooldown += recharge;
    }
    IEnumerator Flash()
    {
        for (int i = 0; i < 6; i++)
        {
            sr.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
        isFlash = false;
    }
    IEnumerator delaydie()
    {
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
