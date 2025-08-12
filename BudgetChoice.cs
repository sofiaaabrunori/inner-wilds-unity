using UnityEngine;
using UnityEngine.SceneManagement;

public class BudgetChoice : MonoBehaviour
{
    // Metodo per caricare la scena "Scenes/AgeChoice"
    public void LoaBedroomScene()
    {
        SceneManager.LoadScene("Scenes/bedroom");
    }
}
