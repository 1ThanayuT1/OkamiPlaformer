using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OTK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.instantKill(3);
        }

        if (collision.gameObject.tag == "Talisman")
        {
            Destroy(gameObject);
            Talisman.instance.Talismanhit();
        }
    }
}
