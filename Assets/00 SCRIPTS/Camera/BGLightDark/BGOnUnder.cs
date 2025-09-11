using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGOnUnder : MonoBehaviour
{
    [SerializeField] protected GameObject _onGround;
    [SerializeField] protected GameObject _underGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UnderGround"))
        {
            _onGround.SetActive(false);
            _underGround.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UnderGround"))
        {
            _onGround.SetActive(true);
            _underGround.SetActive(false);
        }
    }
}
