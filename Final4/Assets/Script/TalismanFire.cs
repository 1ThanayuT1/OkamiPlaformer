using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalismanFire : MonoBehaviour
{
    [SerializeField] private GameObject Talisman;
    [SerializeField] private Transform FirePoint;

    public static TalismanFire instance;
    // Start is called before the first frame update
    private void Awake()
    {
        FirePoint = GetComponent<Transform>();
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireTalisman()
    {
        Instantiate(Talisman, FirePoint.position, Quaternion.identity);
    }
}
