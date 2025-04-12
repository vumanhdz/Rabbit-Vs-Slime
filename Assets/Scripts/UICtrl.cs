using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICtrl : MonoBehaviour
{
    [SerializeField] private GameObject PausePn;
    public void Pause()
    {
        PausePn.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayPause()
    {
        PausePn.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1.0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuLv");
        Time.timeScale = 1.0f;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Lv" + levelIndex);
        Time.timeScale = 1.0f;
    }
    public void Next_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
}
