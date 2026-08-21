using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    public static PauseMenuUI instance;

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Resume Countdown")]
    [SerializeField] private GameObject _countdownPanel;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private int _countdownTimer = 3;
    [SerializeField] private AudioSource _sfxTick;

    public bool IsPaused => _isPaused;
    private AudioSource _bgmSource; 
    InputAction _pauseAction;
    bool _isPaused = false;
    bool _isCountingDown = false;

    void Awake()
    {
        instance = this;
        InputSystem.actions.FindActionMap("UI").Enable();
        _pauseAction = InputSystem.actions.FindAction("Cancel");
    }
    void Start()
    {
        GameObject bgmObject = GameObject.FindWithTag("BGM");

        if(bgmObject != null) _bgmSource = bgmObject.GetComponent<AudioSource>();
        if (_pauseButton != null) _pauseButton.GetComponent<Button>().onClick.AddListener(PauseGame);
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
    public void PauseGame()
    {
        _isPaused = true;
        _pausePanel.SetActive(true);
        _pauseButton.SetActive(false);
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
        _isPaused = false;
        _isCountingDown = true;
        _pausePanel.SetActive(false);
        _settingsPanel.SetActive(false);

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

        _pauseButton.SetActive(true);
        _isCountingDown = false;
        Time.timeScale = 1f;
        if (_bgmSource != null) _bgmSource.UnPause();
    }
    public void BackToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
