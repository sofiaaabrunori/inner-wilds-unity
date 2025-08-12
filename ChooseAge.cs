using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarChoice : MonoBehaviour
{
    // Metodo per caricare la scena "Scenes/AgeChoice"
    public void LoadAvatarChoiceScene()
    {
        SceneManager.LoadScene("Scenes/AvatarChoice");
    }
}
