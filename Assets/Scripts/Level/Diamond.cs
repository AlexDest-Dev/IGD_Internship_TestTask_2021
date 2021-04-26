using Player;
using UnityEngine;

namespace Level
{
    public class Diamond : MonoBehaviour
    {
        [SerializeField] private int diamondValue = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackMovement movement))
            {
                EventBroker.CallUpdateMoney(diamondValue);
                gameObject.SetActive(false);
            }
        }
    }
}
