using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwan : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform spawnPoint;
    private float time;

    public static BulletSpwan instance;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnPoint = GetComponent<Transform>();
        instance = this;
    }
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            time = 0;
            Instantiate(Bullet,spawnPoint.position,Quaternion.identity);
        }
    }
}
