using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer ED1;
    [SerializeField] private VideoPlayer ED2;
    [SerializeField] private VideoPlayer ED3;
    private int ed1 = 0;
    private int ed2 = 0;
    private int ed3 = 0;

    public static EndVideo instance;
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
        ED1Stop();
        ED2Stop();
        ED3Stop();
    }

    public void Ending1()
    {
        ED1.Play();
        ed1++;
    }
    public void Ending2()
    {
        ED2.Play();
        ed2++;
    }
    public void Ending3()
    {
        ED3.Play();
        ed3++;
    }
    void ED1Stop()
    {
        if (Input.GetMouseButtonDown(0) && ed1 == 1)
        {
            ED1.Stop();
            ED1.gameObject.SetActive(false);
            EndText.instance.Ending1();
        }
    }
    void ED2Stop()
    {
        if (Input.GetMouseButtonDown(0) && ed2 == 1)
        {
            ED2.Stop();
            ED2.gameObject.SetActive(false);
            EndText.instance.Ending2();
        }
    }
    void ED3Stop()
    {
        if (Input.GetMouseButtonDown(0) && ed3 == 1)
        {
            ED3.Stop();
            ED3.gameObject.SetActive(false);
            EndText.instance.Ending3();
        }
    }
}
