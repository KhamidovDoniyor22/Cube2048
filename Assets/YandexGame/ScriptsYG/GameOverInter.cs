using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameOverInter : MonoBehaviour
{
    [SerializeField] private float timerShow;
    private float timer;
    private bool isOneShow;

    private void OnEnable()
    {
        isOneShow = true;
    }


    private void Update()
    {
        if (!YandexGame.isShowInter && isOneShow)
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= timerShow)
            {
                timer = 0;
                isOneShow = false;
                Debug.Log("GameOverInter");
                YandexGame.FullscreenShow();
            }
        }
       
    }
}
