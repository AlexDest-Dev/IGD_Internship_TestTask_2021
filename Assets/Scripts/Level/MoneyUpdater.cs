using Data;
using UnityEngine;

namespace Level
{
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
}
