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

    private void Update()
    {
        this.InputPauseMenu();
    }

    protected void InputPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _pauseButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _pauseButton.SetActive(false);
        }
    }

}
