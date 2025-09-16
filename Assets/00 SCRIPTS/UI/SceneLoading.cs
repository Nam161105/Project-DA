using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] protected GameObject _sceneLoading;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected float _timeLoadScene;
    [SerializeField] protected int _id;

    protected bool _hasStartedLoading = false;

    private void Update()
    {
        if (!_hasStartedLoading)
        {
            _timeLoadScene -= Time.deltaTime;
            if (_timeLoadScene <= 0)
            {
                _sceneLoading.SetActive(true);
                _slider.value = 0;
                StartCoroutine(LoadScenAfterTime(_id));
                _hasStartedLoading = true;
            }
        }
    }

    protected IEnumerator LoadScenAfterTime(int id)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(id);

        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            _slider.value = asyncOperation.progress;
            yield return null;
        }

        _slider.value = 1f;

        yield return new WaitForSeconds(1f);
        asyncOperation.allowSceneActivation = true;
    }
}