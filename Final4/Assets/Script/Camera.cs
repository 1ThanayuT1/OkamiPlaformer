using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform bg0;
    [SerializeField] float factor0;

    [SerializeField] private Transform bg1;
    [SerializeField] float factor1;

    [SerializeField] private Transform bg2;
    [SerializeField] float factor2;

    [SerializeField] private Transform bgEssen;

    [SerializeField] private Transform player;

    private float defaultCamera;
    private float nextCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        defaultCamera = transform.position.x;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        nextCamera = transform.position.x;

        bg0.position = new Vector3(bg0.position.x + (nextCamera - defaultCamera) * factor0, bg0.position.y, bg0.position.z);
        bg1.position = new Vector3(bg1.position.x + (nextCamera - defaultCamera) * factor1, bg1.position.y, bg1.position.z);
        bg2.position = new Vector3(bg2.position.x + (nextCamera - defaultCamera) * factor2, bg2.position.y, bg2.position.z);
        bgEssen.position = new Vector3(bgEssen.position.x + (nextCamera - defaultCamera), bgEssen.position.y, bgEssen.position.z);
    }
}
