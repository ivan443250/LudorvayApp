using UnityEngine;
using UnityEngine.SceneManagement;

namespace LogicOutsideScene
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int index) 
        { 
            SceneManager.LoadScene(index);
        }

        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
