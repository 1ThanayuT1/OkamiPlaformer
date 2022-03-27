using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    [SerializeField] private GameObject EDT1;
    [SerializeField] private GameObject EDT2;
    [SerializeField] private GameObject EDT3;

    public static EndText instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ending1()
    {
        EDT1.SetActive(true);
    }
    public void Ending2()
    {
        EDT2.SetActive(true);
    }
    public void Ending3()
    {
        EDT3.SetActive(true);
    }
}
