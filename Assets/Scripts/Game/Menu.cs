using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject gameCanavs;

    public bool isMenu = true;
    //private void Start()
    //{
    //    Time.timeScale = 0;
    //}
    public void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
