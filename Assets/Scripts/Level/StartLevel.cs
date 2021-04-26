using UnityEngine;

namespace Level
{
    public class StartLevel : MonoBehaviour
    {
        private bool _isLevelStarted = false;
        private void Update()
        {
            if (!_isLevelStarted && Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    _isLevelStarted = true;
                    EventBroker.CallLevelStarted();
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
