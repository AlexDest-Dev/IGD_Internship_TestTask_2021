using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _playerAnimationController;

        private void Start()
        {
            _playerAnimationController = GetComponent<Animator>();
            EventBroker.LevelCompleted += EnableVictoryAnimation;
            EventBroker.LevelFailed += EnableFailedAnimation;
            EventBroker.CubeAbsorbed += EnableJumpDownAnimation;
            EventBroker.ObstacleCubeCollided += EnableJumpDownAnimation;
            EventBroker.StackableCubeTriggered += EnableJumpUpAnimation;
        }

        private void EnableJumpDownAnimation(GameObject obj)
        {
            _playerAnimationController.SetTrigger("IsJumpDown");
        }

        private void EnableFailedAnimation()
        {
            _playerAnimationController.SetBool("IsLevelFailed", true);
        }

        private void EnableJumpUpAnimation(GameObject obj)
        {
            _playerAnimationController.SetTrigger("IsJumpUp");
        }

        private void EnableVictoryAnimation()
        {
            _playerAnimationController.SetBool("IsLevelComplete", true);
        }

        private void OnDestroy()
        {
            EventBroker.LevelCompleted -= EnableVictoryAnimation;
            EventBroker.CubeAbsorbed -= EnableJumpDownAnimation;
            EventBroker.ObstacleCubeCollided -= EnableJumpDownAnimation;
            EventBroker.StackableCubeTriggered -= EnableJumpUpAnimation;
            EventBroker.LevelFailed -= EnableFailedAnimation;
        }
    }
}
