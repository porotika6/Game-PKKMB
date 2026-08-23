using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public static StartGame instance;
    [SerializeField] private GameObject _countdownPanel;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private int _countdownTimer = 3;
    [SerializeField] private AudioSource _sfxTick;

    public bool IsCountingDown => _isCountingDown;
    public bool _isCountingDown = false;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(StartCountdown());
    }
    public IEnumerator StartCountdown()
    {
        _isCountingDown = true;
        if (_countdownPanel != null) _countdownPanel.SetActive(true);

        int count = _countdownTimer;
        while (count > 0)
        {
            if (_countdownText != null) _countdownText.text = count.ToString();
            if (_sfxTick != null) _sfxTick.Play();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        if (_countdownPanel != null) _countdownPanel.SetActive(false);
        _isCountingDown = false;

        Time.timeScale = 1f;
    }
}