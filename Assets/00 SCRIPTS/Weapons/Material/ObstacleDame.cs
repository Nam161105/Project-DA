using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IDame dame = collision.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakDame(4000, 4001);
            }
        }
    }
}
