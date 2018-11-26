using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Base : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    HpManager hpManager;

    private void Awake()
    {
        hpManager = GetComponent<HpManager>();
        hpManager.OnDestroyCallback += GameOver;
    }


    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void btnExit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void btnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
