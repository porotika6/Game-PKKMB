using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [Header("Script sources")]
    [SerializeField] private Player_Jump_Input _playerJumpScript;
    [SerializeField] private Coin _coinScript;

    [Header("Audio")]
    [SerializeField] private AudioSource _sfxJump;
    [SerializeField] private AudioSource _sfxCoin;
    [SerializeField] private AudioSource _sfxGameOver;

    private void Start() {
        _playerJumpScript.OnJump += PlayJumpSFX;
        Game_Over.instance.OnGameOver += PlayGameOverSFX;
        
        if(ScoreManager.instance != null) 
            ScoreManager.instance.OnCoinTrigger += PlayCoinSFX;
    }
    private void OnDestroy() {
        _playerJumpScript.OnJump -= PlayJumpSFX;
        Game_Over.instance.OnGameOver -= PlayGameOverSFX;
        
        if(ScoreManager.instance != null) 
            ScoreManager.instance.OnCoinTrigger -= PlayCoinSFX;
    }

    private void PlayGameOverSFX()
    {
        _sfxGameOver.Play();
    }
    private void PlayCoinSFX()
    {
        _sfxCoin.Play();
    }
    private void PlayJumpSFX()
    {
        _sfxJump.Play();
    }
}