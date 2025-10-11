using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormLogin : MonoBehaviour
{
    [SerializeField] protected InputField _inputField;
    [SerializeField] protected int _maxLength;
    [SerializeField] protected GameObject _nameNull;
    [SerializeField] protected GameObject _maxName;

    [SerializeField] protected GameObject _sceneLoading;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected int _id;
    [SerializeField] protected Text _textLoading;

    [SerializeField] protected GameObject _skippButton;

    private void Start()
    {
        string savedName = PlayerPrefs.GetString("PlayerName", "");
        if (!string.IsNullOrEmpty(savedName))
        {
            if(_skippButton != null)
            {
                _skippButton.SetActive(true);
            }
            _inputField.text = savedName;
        }
        else
        {
            if (_skippButton != null)
            {
                _skippButton.SetActive(false);
            }
        }
    }
    public void SaveName()
    {
        string playerName = _inputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            _nameNull.gameObject.SetActive(true);
            _maxName.gameObject.SetActive(false);
            return;
        }
        if(playerName.Length > _maxLength)
        {
            _nameNull.gameObject.SetActive(false);
            _maxName.gameObject.SetActive(true);
            return;
        }

        _nameNull.gameObject.SetActive(false);
        _maxName.gameObject.SetActive(false);
        PlayerPrefs.SetString("PlayerName", playerName);

        _sceneLoading.SetActive(true);
        _slider.value = 0;
        StartCoroutine(LoadScenAfterTime(_id));

    }

    protected IEnumerator LoadScenAfterTime(int id)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(id);

        while (!asyncOperation.isDone)
        {
            float slider = Mathf.Clamp01(asyncOperation.progress);
            int textLoad = Mathf.RoundToInt(asyncOperation.progress * 100f);

            _slider.value = slider;
            _textLoading.text = textLoad + "%";
            if(asyncOperation.progress > 0.9f)
            {
                _slider.value = 1;
                _textLoading.text = "100%";
                yield return new WaitForSeconds(0.5f);
            } 
            
            yield return null;
        }
    }

    public void SkippButton()
    {
        _sceneLoading.SetActive(true);
        _slider.value = 0;
        StartCoroutine(LoadScenAfterTime(_id));
    }
}
