using UnityEngine;

namespace Player
{
    public class StackMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 1f;
        [SerializeField] private float sideSpeed = 1f;
        [SerializeField] private float rightBorder = 2f;
        [SerializeField] private float leftBorder = -2f;
        private Touch _touch;
        private float _width;
        private bool _canMove;
        void Start()
        {
            EventBroker.LevelStarted += EnableMove;
            EventBroker.LevelCompleted += DisableMove;
            EventBroker.LevelFailed += DisableMove;
        
            _width = (float) Screen.width;
        }
        void FixedUpdate()
        {
            if (_canMove)
            {
                float xDirection = GetXDirection();
                Movement(xDirection);
            }
        }

        private float GetXDirection()
        {
            float direction = 0f;
        
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
            
                if (_touch.phase == TouchPhase.Moved)
                {
                    float changeX = _touch.deltaPosition.x - _width;
                    if (changeX > 0)
                    {
                        direction = -1f;
                    }
                    else
                    {
                        direction = 1f;
                    }
                }
            }
            return direction * _touch.deltaPosition.x;
        }

        private void Movement(float xDirection)
        {
            Vector3 force = new Vector3(xDirection * sideSpeed, 0f, 1f * forwardSpeed) * Time.deltaTime;
            Vector3 curPosition = transform.position;
            if (force.x + transform.position.x < leftBorder)
            {
                transform.position = new Vector3(leftBorder, curPosition.y, curPosition.z);
                transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
                return;
            }

            if (force.x + transform.position.x > rightBorder)
            {
                transform.position = new Vector3(rightBorder, curPosition.y, curPosition.z);
                transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
                return;
            }
            transform.Translate(force);
        }

        private void EnableMove()
        {
            _canMove = true;
        }

        private void DisableMove()
        {
            _canMove = false;
        }

        private void OnDestroy()
        {
            EventBroker.LevelStarted -= EnableMove;
            EventBroker.LevelCompleted -= DisableMove;
            EventBroker.LevelFailed -= DisableMove;    
        }
    }
}
