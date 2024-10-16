using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicSlider;

    private void Start()
    {
      LoadVolume();
      MusicManager.Instance.PlayMusic("Main");
    }

    public void Play()
    {
      SceneManager.LoadScene("GameScene");
      MusicManager.Instance.PlayMusic("Main");
    }

    public void Menu()
    {
      SceneManager.LoadScene("GameStartScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
      Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
      Time.timeScale = 1f;
    }

    public void UpdateMusicVolume(float volume)
    {
      audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SaveVolume()
    {
      audioMixer.GetFloat("MusicVolume", out float musicVolume);
      PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void LoadVolume()
    {
      musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
}
