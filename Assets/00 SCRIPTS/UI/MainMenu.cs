using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] protected GameObject _setting;

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Setting()
    {
        _setting.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
