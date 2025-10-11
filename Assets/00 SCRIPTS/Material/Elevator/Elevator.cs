using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] protected Transform _downPos;
    [SerializeField] protected Transform _upPos;
    [SerializeField] protected float _speed;
    [SerializeField] protected bool isElevator = false;

    private void Update()
    {
        float pos = Vector2.Distance(PlayerController.Instance.transform.position, transform.position);
        if (pos < 4f && Input.GetKeyDown(KeyCode.S))
        {
            if (transform.position.y <= _downPos.position.y)
            {
                isElevator = true;
            }
 
        }

        if (isElevator)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _upPos.position, _speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, _upPos.position) <= 2f)
            {
                isElevator = false;
            }
        }

    }
}
