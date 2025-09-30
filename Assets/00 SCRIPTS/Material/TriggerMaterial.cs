using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMaterial : MonoBehaviour
{
    [SerializeField] protected Text _text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _text.GetComponent<Rigidbody2D>().gravityScale = 5;
            this.gameObject.SetActive(false);
        }
    }
}
