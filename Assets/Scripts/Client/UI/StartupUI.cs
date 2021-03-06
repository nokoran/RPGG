using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.UI
{
    /// <summary>
    /// Provides backing logic for any UI before MainMenu stage. Mostly we just load main menu
    /// </summary>
    public class StartupUI : MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

