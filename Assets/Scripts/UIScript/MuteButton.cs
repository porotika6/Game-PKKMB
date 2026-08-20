using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Image _muteButton;
    [SerializeField] private Sprite _muted;
    [SerializeField] private Sprite _unmuted;
    private bool _isMuted;
    
    void Start()
    {
        _isMuted = AudioListener.volume == 0f;
        _muteButton.sprite = _isMuted ? _muted : _unmuted;
    }
    public void ToggleMute()
    {
        _isMuted = !_isMuted;
        AudioListener.volume = _isMuted ? 0f : 1f;       
        _muteButton.sprite = _isMuted ? _muted : _unmuted;
    }
}