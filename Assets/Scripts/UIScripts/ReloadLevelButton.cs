using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIScripts
{
    public class ReloadLevelButton : MonoBehaviour
    {

        public void ReloadScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
