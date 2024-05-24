using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardAd : MonoBehaviour
{
    [SerializeField] private Text rewardText;

    void Start()
    {
        rewardText.text = YandexGame.Instance.countReward.ToString();
    }

    public void ShowReward()
    {
        YandexGame.RewVideoShow(0);
    }



}
