using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _scaleSpeed;

    [SerializeField] Light _light;

    private void Update()
    {
        Move();
        Increase();
    }

    private void Move()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    private void Increase()
    {
        var nextScale = transform.localScale;
        nextScale.x += _scaleSpeed;
        nextScale.y += _scaleSpeed;
        nextScale.z += _scaleSpeed;
        transform.localScale = nextScale;

        _light.range += _scaleSpeed;
        _light.intensity += _scaleSpeed;
    }
}
