using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Resume Countdown")]
    [SerializeField] private GameObject _countdownPanel;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private int _countdownTimer = 3;

    private AudioSource _bgmSource; 
    InputAction _pauseAction;
    bool _isPaused = false;
    bool _isCountingDown = false;

    void Awake()
    {
        InputSystem.actions.FindActionMap("UI").Enable();
        _pauseAction = InputSystem.actions.FindAction("Cancel");
    }
    void Update()
    {
        if(_isCountingDown) return;

        if (_pauseAction.WasPressedThisFrame())
        {
            if (_isPaused) ResumeGame();
            else PauseGame();
        }
    }
    void Start()
    {
        GameObject bgmObject = GameObject.FindWithTag("BGM");

        if(bgmObject != null) _bgmSource = bgmObject.GetComponent<AudioSource>();
    }
    public void PauseGame()
    {
        _isPaused = true;
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
        if(_bgmSource != null) _bgmSource.Pause();
    }
    public void ResumeGame()
    {
        if(_isCountingDown) return;
        StartCoroutine(ResumeWithCountdown());
    }
    private IEnumerator ResumeWithCountdown()
    {
        _isCountingDown = true;
        _pausePanel.SetActive(false);

        if (_countdownPanel != null) _countdownPanel.SetActive(true);

        int count = _countdownTimer;
        while (count > 0)
        {
            if (_countdownText != null) _countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        if (_countdownPanel != null) _countdownPanel.SetActive(false);

        _isPaused = false;
        _isCountingDown = false;
        Time.timeScale = 1f;
        if (_bgmSource != null) _bgmSource.UnPause();
    }
    public void BackToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
