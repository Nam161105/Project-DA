using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsDame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDame dame = collision.gameObject.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakDame(165, 167);
            }
        }
    }
}
