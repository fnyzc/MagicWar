using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_sc : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundEffectSlider;

    public AudioClip menuMusic;

    private void Start()
{
    if (AudioController_sc.Instance != null)
    {
        musicSlider.SetValueWithoutNotify(AudioController_sc.Instance.musicVolume);
        soundEffectSlider.SetValueWithoutNotify(AudioController_sc.Instance.soundEffectVolume);
        if (menuMusic != null)
        {
            AudioController_sc.Instance.PlayMusic(menuMusic, true);
        }
    }
}


    public void OnNewGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMusicSliderChanged(float value)
    {
        if (AudioController_sc.Instance != null)
            AudioController_sc.Instance.musicVolume = value;
    }

    public void OnSoundEffectSliderChanged(float value)
    {
        if (AudioController_sc.Instance != null)
            AudioController_sc.Instance.soundEffectVolume = value;
    }
}
