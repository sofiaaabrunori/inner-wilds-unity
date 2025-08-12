using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOnClick : MonoBehaviour
{
    // Method to load the game version when the button is clicked
    public void LoadGameVersion()
    {
        string persona = MyGameManager.Instance.assignedPersona;
        MyGameManager.Instance.LogAssignedPersona();
        if (persona == "Persona1")
        {
            SceneManager.LoadScene("Scenes/Guitar Hero scenes/Slow"); // Load the easier version
        }
        else if (persona == "Persona2")
        {
            SceneManager.LoadScene("Scenes/Guitar Hero scenes/Guitar Hero"); // Load the harder version
        }
        else
        {
            Debug.LogError("Persona not recognized!");
        }
    }
}

