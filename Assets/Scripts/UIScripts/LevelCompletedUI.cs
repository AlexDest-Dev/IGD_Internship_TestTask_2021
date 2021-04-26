using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class LevelCompletedUI : MonoBehaviour
    {

        private void Start()
        {
            gameObject.SetActive(false);
            EventBroker.LevelCompleted += EnableLevelCompletedUI;
        }

        private void EnableLevelCompletedUI()
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            EventBroker.LevelCompleted -= EnableLevelCompletedUI;
        }
    }
}
