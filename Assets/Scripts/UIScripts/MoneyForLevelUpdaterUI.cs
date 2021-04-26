using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class MoneyForLevelUpdaterUI : MonoBehaviour
    {
        [SerializeField] private PlayerData data;
        private Text _moneyForLevelText;
        private void Awake()
        {
            EventBroker.LevelCompleted += UpdateMoneyForLevel;
            _moneyForLevelText = GetComponent<Text>();
        }

        private void UpdateMoneyForLevel()
        {
            _moneyForLevelText.text = data.MoneyForLevel.ToString();
        }

        private void OnDestroy()
        {
            EventBroker.LevelCompleted -= UpdateMoneyForLevel;
        }
    }
}