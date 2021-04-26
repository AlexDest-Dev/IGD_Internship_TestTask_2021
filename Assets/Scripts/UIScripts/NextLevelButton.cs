using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIScripts
{
    public class NextLevelButton : MonoBehaviour
    {


        //TODO: Implement changing of levels
        public void NextLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
