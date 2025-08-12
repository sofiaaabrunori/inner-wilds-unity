using UnityEngine;
using UnityEngine.SceneManagement;

public class IndependentMusicPlayer : MonoBehaviour
{
    private static IndependentMusicPlayer instance; // Singleton locale per evitare duplicati
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton locale per evitare duplicati in caso di ricarica
        if (instance != null)
        {
            Destroy(gameObject); // Distruggi duplicati
            return;
        }

        instance = this; 
        DontDestroyOnLoad(gameObject); // Mantieni il GameObject tra le scene

        // Recupera l'AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource non trovato! Aggiungine uno al GameObject.");
            return;
        }

        // Avvia la musica
        PlayMusic();

        // Ascolta il caricamento delle scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scena caricata: " + scene.name);

        // Controlla se siamo nella scena SleepPlayer
        if (scene.name == "SleepPlayer")
        {
            Debug.Log("Fermo la musica perché siamo nella scena SleepPlayer");
            StopMusic();
        }
    }

    // Metodo per avviare la musica
    private void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
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
