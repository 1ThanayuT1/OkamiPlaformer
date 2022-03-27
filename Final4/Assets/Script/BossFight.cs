using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public int bossHP = 3;
    [SerializeField] private Rigidbody2D rbplayer;

    public static BossFight instance;
    // Start is called before the first frame update
    private void Awake()
    {
        rbplayer = GameObject.Find("Player_stand_01").GetComponent<Rigidbody2D>();
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bossHP == 0)
        {
            Boss.instance.BossDie();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rbplayer.velocity = new Vector2(rbplayer.velocity.x, 5);
            bossHP--;
            MainBGM.instance.GameEnd();
            StartCoroutine(ShieldReturning());
        }
    }

    IEnumerator ShieldReturning()
    {
        yield return new WaitForSeconds(0.001f);
        Boss.instance.ShieldRestore();
    }
}
