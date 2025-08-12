using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private AudioSource AudioSource;

    void Start()
    {
        // Controlla se il volume è salvato
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1); // Valore di default
        }
        Load(); // Carica sempre il valore del volume
    }

    public void ChangeVolume()
    {
        AudioListener.volume = Slider.value;
        Save();
    }

    private void Load()
    {
        float savedVolume = PlayerPrefs.GetFloat("musicVolume");
        Slider.value = savedVolume;
        AudioSource.volume = savedVolume;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", Slider.value);
    }
}
