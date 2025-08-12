using UnityEngine;
using UnityEngine.SceneManagement;

public class GenderChoose : MonoBehaviour
{
    // Metodo da associare ai pulsanti
    public void LoadAgeChoiceScene()
    {
        // Carica la scena chiamata "Scenes/AgeChoice"
        SceneManager.LoadScene("Scenes/AgeChoice");
    }
}

