using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] protected GameObject _pauseButton;

    public void Pause()
    {
        _pauseButton.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        _pauseButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void DeleteName()
    {
        Time.timeScale = 1f;
        PlayerPrefs.DeleteKey("PlayerName");
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Time.timeScale = 0f;
        Application.Quit();
        _pauseButton.SetActive(false);
    }

    public void Cancel()
    {
        _pauseButton.SetActive(false);
        Time .timeScale = 1f;
    }


}
