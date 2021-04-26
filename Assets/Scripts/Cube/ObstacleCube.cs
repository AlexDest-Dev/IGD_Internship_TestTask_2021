using UnityEngine;

namespace Cube
{
    public class ObstacleCube : MonoBehaviour
    {
        [SerializeField] private bool isObstacle;
        [SerializeField] private float cubeSize = 1f;
    
        public bool IsObstacle => isObstacle;
        public float CubeSize => cubeSize;

        private bool _isActive = false;
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }
}
