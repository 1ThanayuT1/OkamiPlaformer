using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Text textTalisman;
    [SerializeField] private GameObject PausePanel;

    public static UIControl instance;

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
        TalismanAmount();
        MenuUp();
    }

    public void TalismanAmount()
    {
        textTalisman.text = Gameplay.instance.coin.ToString();
    }

    public void MenuUp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
