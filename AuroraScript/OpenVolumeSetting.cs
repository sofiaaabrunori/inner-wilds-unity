using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadVolumeSettingScene : MonoBehaviour
{
    public void LoadScene()
    {
        // Carica la scena VolumeSetting
        SceneManager.LoadScene("Scenes/VolumeSetting");
    }
}
