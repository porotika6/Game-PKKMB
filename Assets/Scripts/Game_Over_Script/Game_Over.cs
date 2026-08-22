using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System;

public class Game_Over : MonoBehaviour
{
    public static Game_Over instance;

    public event Action OnGameOver;
    public Animator transition;        // Image hitam full-screen buat transisi (alpha 0 di awal)
    public GameObject gameOverPanel;   
    public TMP_Text GameOverText; 
    public TMP_Text finalScoreText;  
    public TMP_Text highScoreText;
    public float fadeDuration = 1f;

    private bool _isGameOver = false;
    private AudioSource _bgmSource;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        GameObject bgmObject = GameObject.FindWithTag("BGM");

        if (bgmObject != null) _bgmSource = bgmObject.GetComponent<AudioSource>();
    }
    public void GameOver()
    {
        if (_isGameOver) return;   // biar gak jalan dua kali
        _isGameOver = true;
        StartCoroutine(GameOverSequence());
        OnGameOver?.Invoke();
    }
    private IEnumerator GameOverSequence()
    {
        Time.timeScale = 0f;

        bool isNewHighScore = ScoreManager.instance.Score > PlayerPrefs.GetFloat("HighScore");
    
        ScoreManager.instance.SaveHighScore();
        if(_bgmSource != null) _bgmSource.Stop();
        ScoreManager.instance.gameSpeed = 0f;
        transition.Play("Transistion anim");                   // suruh animator mainin fade
        yield return new WaitForSecondsRealtime(fadeDuration);
        Debug.Log("Trigger kepanggil");

        gameOverPanel.SetActive(true);
        GameOverText.text = "Game Over";
        finalScoreText.text = "Score: " + Mathf.FloorToInt(ScoreManager.instance.Score);

        if(isNewHighScore){
            highScoreText.text = "New High Score: " + Mathf.FloorToInt(ScoreManager.instance.HighScore);
        } else
        {
            highScoreText.text = "High Score: " + Mathf.FloorToInt(ScoreManager.instance.HighScore);
        }
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene");
    }
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
