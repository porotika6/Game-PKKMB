using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1f;
    }
    public void OnPlayButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
