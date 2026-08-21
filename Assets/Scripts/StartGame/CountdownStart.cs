using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownStart : MonoBehaviour
{
    [SerializeField] private GameObject _countdownPanel;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private int _countdownTimer = 3;
    [SerializeField] private AudioSource _sfxTick;

    void Start()
    {
        Time.timeScale = 0f;   // game berhenti dulu selama countdown
        StartCoroutine(StartWithCountdown());   // langsung mulai countdown
    }

    private IEnumerator StartWithCountdown()
    {
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

        Time.timeScale = 1f;   // countdown selesai → game mulai
    }
}