using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadQuitScene : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Scenes/DontQuit");
    }
}
