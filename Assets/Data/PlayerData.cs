using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Data", order = 1)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int moneyAmount = 0;
        private int _moneyForLevel = 0;
        
        public int MoneyAmount => moneyAmount;

        public int MoneyForLevel
        {
            get => _moneyForLevel;
            set
            {
                if (value >= 0)
                {
                    _moneyForLevel = value;
                }
            }
        }

        private void Awake()
        {
            LoadData();
        }

        private void LoadData()
        {
            String destination = Application.persistentDataPath + "/save.dat";
            FileStream file;
            
            if (File.Exists(destination))
            {
                file = File.OpenRead(destination);
                BinaryFormatter bf = new BinaryFormatter();
                String savedData = (String) bf.Deserialize(file);
                JsonUtility.FromJsonOverwrite(savedData, this);
                file.Close();
            }
            else
            {
                SaveData();
                LoadData();
            }
        }

        public void IncreaseMoneyAmount(int value)
        {
            moneyAmount += value;
            SaveData();
        }

        private void OnDestroy()
        {
            SaveData();
        }

        private void SaveData()
        {
            String saveData = JsonUtility.ToJson(this, true);
            String destination = Application.persistentDataPath + "/save.dat";
            FileStream file;
            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);
            }
            else
            {
                file = File.Create(destination);
            }

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
            file.Close();
        }
    }
}
