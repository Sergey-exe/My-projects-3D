using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeEnlarger : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;

    [SerializeField] private Light _light;

    private void Update()
    {
        transform.localScale = transform.localScale + Vector3.one * _scaleSpeed;

        _light.range += _scaleSpeed;
        _light.intensity += _scaleSpeed;
    }
}
