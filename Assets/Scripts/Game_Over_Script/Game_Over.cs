using UnityEngine;
using TMPro;
using System.Collections;

public class Game_Over : MonoBehaviour
{
    public static Game_Over instance;

    public Animator transition;        // Image hitam full-screen buat transisi (alpha 0 di awal)
    public GameObject gameOverPanel;   
    public TMP_Text GameOverText; 
    public TMP_Text finalScoreText;  
    public float fadeDuration = 1f;

    private bool _isGameOver = false;

    void Awake()
    {
        instance = this;
    }
      public void GameOver()
    {
        if (_isGameOver) return;   // biar gak jalan dua kali
        _isGameOver = true;
        StartCoroutine(GameOverSequence());
    }
    private IEnumerator GameOverSequence()
    {
        Time.timeScale = 0f;
        ScoreManager.instance.gameSpeed = 0f;
        Debug.Log("Transition null? " + (transition == null)); 
        transition.Play("Transistion anim");                   // suruh animator mainin fade
        yield return new WaitForSecondsRealtime(fadeDuration);
        Debug.Log("Trigger kepanggil");

        gameOverPanel.SetActive(true);
        GameOverText.text = "Game Over";
        finalScoreText.text = "Score: " + Mathf.FloorToInt(ScoreManager.instance._score);
       
    }

}
