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

    void Start()
    {
        if(_audioMixer.GetFloat("MusicParam", out float musicDb))
        {
            float musicValue = Mathf.Pow(10f, musicDb / 20);
            _musicSlider.SetValueWithoutNotify(musicValue);
            _musicValue.text = Mathf.RoundToInt(musicValue * 100).ToString();
        }
        if(_audioMixer.GetFloat("SFXParam", out float sfxDb))
        {
            float sfxValue = Mathf.Pow(10f, sfxDb / 20);
            _sfxSlider.SetValueWithoutNotify(sfxValue);
            _sfxValue.text = Mathf.RoundToInt(sfxValue * 100).ToString();
        }
    }
    void Update()
    {
        if(StartGame.instance.IsCountingDown) gameObject.SetActive(false);
    }
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
