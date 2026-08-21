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

    public bool IsPaused => _isPaused;
    private AudioSource _bgmSource; 
    InputAction _pauseAction;
    bool _isPaused = false;

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
        if (Countdown.instance != null && Countdown.instance.IsCountingDown) return;

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
        if(Countdown.instance != null && Countdown.instance.IsCountingDown) return;
        StartCoroutine(ResumeAfterhCountdown());
    }
    private IEnumerator ResumeAfterhCountdown()
    {
        _pausePanel.SetActive(false);
        yield return StartCoroutine(Countdown.instance.StartCountdown());

        _isPaused = false;
        _pauseButton.SetActive(true);
        if (_bgmSource != null) _bgmSource.UnPause();
    }
    public void BackToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
