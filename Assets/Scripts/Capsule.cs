using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;

    [SerializeField] private Light _light;

    private void Update()
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
