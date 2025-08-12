using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Scenes/AgeChoice");
    }
}

