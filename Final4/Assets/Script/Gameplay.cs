using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public int coin = 0;
    public int ball = 0;
    public int omamori = 0;
    public int maxHp = 3;
    public int maxTalis = 5;

    [SerializeField] private GameObject Portal;

    public static Gameplay instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getCoin(int getCoin)
    {
        coin += getCoin;

        if (coin > maxTalis)
        {
            coin = maxTalis;
        }
    }

    public void UseTalisman()
    {
        coin--;
    }

    public void getOmamori(int getOmamori)
    {
        omamori += getOmamori;
    }

    public void getBall(int getBall)
    {
        ball += getBall;
    }

    public void PortalOpen()
    {
        Portal.SetActive(true);
    }
}
