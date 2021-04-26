using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class LevelFailedUI : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
            EventBroker.LevelFailed += EnableLevelFailedUI;
        }

        private void EnableLevelFailedUI()
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            EventBroker.LevelFailed -= EnableLevelFailedUI;
        }
    }
}