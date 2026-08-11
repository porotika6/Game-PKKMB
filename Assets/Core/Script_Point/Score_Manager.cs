using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public static Scoremanager instance;
    public float pointpersecond = 0f;
    public TMP_Text scoretext;
    public float _score;
    public float gameSpeed = 5f;
    float speedBoost = 2f;
    public float maxSpeed = 20f;
    private int _nextMilestone = 500;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        _score += pointpersecond * Time.deltaTime;
        scoretext.text = "Score: " + Mathf.FloorToInt(_score);

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
}
