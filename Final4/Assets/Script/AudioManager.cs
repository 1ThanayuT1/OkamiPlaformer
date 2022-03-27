using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip item;
    [SerializeField] private AudioClip ghost;

    [SerializeField] private AudioSource audioSource;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playsound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void playJump()
    {
        playsound(jump);
    }
    public void playItem()
    {
        playsound(item);
    }
    public void playGhost()
    {
        playsound(ghost);
    }
}
