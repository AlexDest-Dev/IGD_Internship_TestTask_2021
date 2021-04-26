using UnityEngine;

namespace Cube
{
    public class CubeAbsorber : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackableCube controller))
            {
                EventBroker.CallCubeAbsorbed(other.gameObject);
            }
        }
    }
}
