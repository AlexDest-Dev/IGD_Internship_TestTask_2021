using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUpdaterUI : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    private Text _moneyText;

    private void Start()
    {
        _moneyText = GetComponent<Text>();
        EventBroker.LevelCompleted += UpdateMoneyUI;
        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        _moneyText.text = data.MoneyAmount.ToString();
    }

    private void OnDestroy()
    {
        EventBroker.LevelCompleted -= UpdateMoneyUI;
    }
}
