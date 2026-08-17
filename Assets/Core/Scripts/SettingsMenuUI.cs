using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Music Refrences")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private TextMeshProUGUI _musicValue;

    [Header("SFX Refrences")]
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private TextMeshProUGUI _sfxValue;

    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _musicValue.text = Mathf.RoundToInt(volume * 100).ToString();
        _audioMixer.SetFloat("MusicParam", Mathf.Log10(volume)*20);
    }
    public void SetSFXVolume()
    {
        float volume = _sfxSlider.value;
        _sfxValue.text = Mathf.RoundToInt(volume * 100).ToString();
        _audioMixer.SetFloat("SFXParam", Mathf.Log10(volume)*20);
    }
}
