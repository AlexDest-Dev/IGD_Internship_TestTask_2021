using Player;
using UnityEngine;

namespace Level
{
    public class FinishLevel : MonoBehaviour
    {
        private bool _isLevelFinished = false;
        private void OnTriggerEnter(Collider other)
        {
            if (!_isLevelFinished && other.TryGetComponent(out StackMovement stuckMovement))
            {
                _isLevelFinished = true;
                EventBroker.CallLevelFinished();
            }
        }
    }
}
