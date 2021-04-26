using Player;
using UnityEngine;

namespace Cube
{
    public class StackableCube : MonoBehaviour
    {
        [SerializeField] private float cubeSize = 1f;
    
        public float CubeSize => cubeSize;

        private bool _isActive = false;
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackMovement stuckMovement) && GetComponent<BoxCollider>().isTrigger)
            {
                EventBroker.CallStackableCubeTriggered(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out ObstacleCube otherCubeController) && otherCubeController.IsObstacle)
            {
                _isActive = false;
            
                transform.SetParent(null);
            
                GetComponent<Rigidbody>().constraints =
                    RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
            
                EventBroker.CallObstacleCubeCollided(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            if (_isActive == false)
            {
                EventBroker.CallStackableCubeInvisible(gameObject);
            }
        }
    }
}
