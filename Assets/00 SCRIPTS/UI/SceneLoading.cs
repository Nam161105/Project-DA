using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] protected PlayableDirector _playableDirector;


    private void Start()
    {
        _playableDirector.Play();
        _playableDirector.stopped += OnSkippable;
    }

    protected void OnSkippable(PlayableDirector playableDirector)
    {
        _playableDirector.stopped -= OnSkippable;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SkippIntro()
    {
        _playableDirector.Stop();
    }

}
