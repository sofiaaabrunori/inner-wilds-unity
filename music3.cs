using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicManager : MonoBehaviour
{
    private static SceneMusicManager instance; // Singleton locale per evitare duplicati
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton locale per evitare duplicati
        if (instance != null)
        {
            Destroy(gameObject); // Distruggi duplicati
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Mantieni il GameObject tra le scene

        // Recupera o aggiungi l'AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.LogWarning("AudioSource non trovato! Ne ho creato uno automaticamente.");
        }

        // Avvia la musica
        PlayMusic();

        // Ascolta il caricamento delle scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scena caricata: " + scene.name);

        // Controlla se siamo nella scena FinalScene
        if (scene.name == "FinalScene")
        {
            Debug.Log("Fermo la musica perché siamo nella scena FinalScene");
            StopMusic();
        }
    }

    // Metodo per avviare la musica
    private void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.loop = true; // Assicura che la musica sia in loop
            audioSource.Play();
        }
    }

    // Metodo per fermare la musica
    private void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void OnDestroy()
    {
        // Rimuovi il listener per evitare memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
