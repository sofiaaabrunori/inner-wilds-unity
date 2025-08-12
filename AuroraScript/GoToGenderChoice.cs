using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAgeChoiceScene : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Scenes/AgeChoice");
    }
}
