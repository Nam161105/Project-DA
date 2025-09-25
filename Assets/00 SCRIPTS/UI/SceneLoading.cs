using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] protected float _timeLoadScene;


    private void Update()
    {
        _timeLoadScene -= Time.deltaTime;
        if (_timeLoadScene <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}
