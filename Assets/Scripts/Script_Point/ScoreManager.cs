using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public event Action OnCoinTrigger;
    public float pointpersecond = 0f;
    public TMP_Text scoretext;
    public TMP_Text highScoreText;
    public float _score;
    public float gameSpeed = 5f;
    float speedBoost = 2f;
    public float maxSpeed = 20f;
    private int _nextMilestone = 500;
    private float _highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;

        _highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = $"High score: {Mathf.FloorToInt(_highScore)}";
    }

    // Update is called once per frame
    void Update()
    {
        _score += pointpersecond * Time.deltaTime;
        scoretext.text = "Score: " + Mathf.FloorToInt(_score);

        if (_score > _highScore)
        {
            _highScore = _score;
            highScoreText.text = "High score: " + Mathf.FloorToInt(_highScore);
        }

        if (_score >= _nextMilestone)
        {
            gameSpeed += speedBoost;
            gameSpeed = Mathf.Min(gameSpeed, maxSpeed);
            _nextMilestone += 500;
            Debug.Log("Game speed Increased to:" + gameSpeed);
        }
    }
    public void AddScore(int amount)
    {
        _score += amount;
    }
    public void CoinCollected()
    {
        Debug.Log("COIN COLLECTED EVENT DIPANGGIL");

        OnCoinTrigger?.Invoke();
    }
    public void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", Mathf.FloorToInt(_highScore));
        PlayerPrefs.Save();
    }

    public float getHighScore()
    {
        return _highScore;
    }
}
