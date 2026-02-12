using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject audioPanel;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] AudioMixer mixer;
    [SerializeField] string exposedMusic;
    [SerializeField] string exposedSFX;
    void Start()
    {
        MusicSlider.value = MusicSlider.maxValue;
        SFXSlider.value = SFXSlider.maxValue;

        SetMusicVolume();
        SetSFXVolume();
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void ToggleAudio()
    {
        audioPanel.SetActive(!audioPanel.activeSelf);
    }
    public void SetMusicVolume()
    {
        float slider = Mathf.Max(MusicSlider.value, 0.0001f);
        float dB = Mathf.Log10(slider) * 20f;
        mixer.SetFloat(exposedMusic, dB);
    }
        public void SetSFXVolume()
    {
        float sliderValue = Mathf.Max(SFXSlider.value, 0.0001f);
        float dB = Mathf.Log10(sliderValue) * 20f;
        mixer.SetFloat(exposedSFX, dB);
    }

}
