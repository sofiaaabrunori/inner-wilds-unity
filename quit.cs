using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Metodo da collegare al pulsante Quit
    public void Quit()
    {
        // Log per test durante l'editor (Unity Editor non può chiudere il gioco)
        Debug.Log("Quitting the game...");

        // Chiude l'applicazione
        Application.Quit();
    }
}
