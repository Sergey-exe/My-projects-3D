using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadios;

    public void Explode(List<Rigidbody> explosionObjects, Transform explodeTransform)
    {
        foreach (Rigidbody cube in explosionObjects)
            cube.AddExplosionForce(_explosionForce, explodeTransform.position, _explosionRadios);
    }
}
