using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameUpdate : MonoBehaviour
{
    [SerializeField] protected Text _textName;
    [SerializeField] protected float _offsetY;

    private void Start()
    {
        string savedName = PlayerPrefs.GetString("PlayerName", "Quest");
        _textName.text = savedName;
    }

    private void Update()
    {
        transform.position = PlayerController.Instance.transform.position + new Vector3(0, _offsetY, 0);
    }
}
