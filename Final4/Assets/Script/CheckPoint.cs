using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] public string CPname;

    public static CheckPoint instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerCheckpoint"))
        {
            if (PlayerPrefs.GetString("PlayerCheckpoint") == CPname)
            {
                Player.instance.transform.position = transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteKey("PlayerCheckpoint");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetString("PlayerCheckpoint", CPname);
        }
    }
}
