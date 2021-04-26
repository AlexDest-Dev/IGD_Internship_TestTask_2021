using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class MoneyUpdater : MonoBehaviour
{
    [SerializeField] private PlayerData data;

    private void Awake()
    {
        data.MoneyForLevel = 0;
        EventBroker.LevelCompleted += UpdatePlayerData;
        EventBroker.UpdateMoney += UpdateCurrentMoney;
    }

    private void UpdateCurrentMoney(int value)
    {
        data.MoneyForLevel += value;
    }

    private void UpdatePlayerData()
    {
        data.IncreaseMoneyAmount(data.MoneyForLevel);
    }

    private void OnDestroy()
    {
        EventBroker.LevelCompleted -= UpdatePlayerData;
        EventBroker.UpdateMoney -= UpdateCurrentMoney;
    }
}
