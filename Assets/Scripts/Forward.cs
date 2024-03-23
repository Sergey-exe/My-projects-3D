using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    [SerializeField] float _speed = 0.5f;

    private void Update()
    {
        var nextPosition = transform.position;
        nextPosition.z += _speed;
        transform.position = nextPosition;
    }
}
