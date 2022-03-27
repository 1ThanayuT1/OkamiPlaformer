using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBGM : MonoBehaviour
{
    [SerializeField] private GameObject mainBGM;
    private int bgmstop = 0;

    public static MainBGM instance;
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
        if (bgmstop == 3)
        {
            mainBGM.SetActive(false);
        }
    }

    public void GameEnd()
    {
        bgmstop++;
    }
}
