using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;


public class TimerAds : MonoBehaviour
{
   private Text timerText;

    private float timer;

    [SerializeField] private GameObject adsPanel;

    private void OnEnable()
    {
        timerText = GetComponent<Text>();

        timer = 3;
        Time.timeScale = 0;
        AudioListener.volume = 0;
        YandexGame.isAd = true;
    }

    private void OnDisable()
    {
        timer = 3;
    }

    void Update()
    {
        timer -= Time.unscaledDeltaTime;
        timerText.text = timer.ToString("N0");
        if (timer <= 0)
        {
            timer = 0;
            YandexGame.FullAdShow();
            adsPanel.SetActive(false);
        }
    }
}
