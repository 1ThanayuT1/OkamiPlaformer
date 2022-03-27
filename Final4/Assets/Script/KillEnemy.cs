using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Rigidbody2D rbplayer;

    // Start is called before the first frame update
    private void Awake()
    {
        rbplayer = GameObject.Find("Player_stand_01").GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rbplayer.velocity = new Vector2(rbplayer.velocity.x, 5);
            Destroy(enemy);
        }
    }
}
