using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;
    private float currentTime;
    private int recordNumber;

    public Text timerText;
    public TextMeshProUGUI recordText;

    public GameObject losePanel;

    public bool isOver = false;
    private void Start()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            TimerFinished();
        }

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = timeString;
    }

    private void TimerFinished()
    {
        if(!isOver)
        {
            recordNumber = PlayerPrefs.GetInt("recordNumber", recordNumber);
            recordText.text = recordNumber.ToString();
            YandexGame.NewLeaderboardScores("score", recordNumber);
            losePanel.SetActive(true);
            Time.timeScale = 0;
            isOver = true;
        }
        
    }
    public void TimeAdd()
    {
        currentTime += 5;
    }
}
