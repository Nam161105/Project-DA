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
    }
    public void Resume()
    {
        _pauseButton.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _pauseButton.SetActive(false);
    }

    public void Cancel()
    {
        _pauseButton.SetActive(false);
    }


}
