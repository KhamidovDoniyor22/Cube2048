using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AutoGameReady : MonoBehaviour
{
    [SerializeField] private float timer;

    void Start()
    {
        Invoke("LoadApi", timer);
    }

    void LoadApi()
    {
        YandexGame.GameReadyAPI();
    }

}
