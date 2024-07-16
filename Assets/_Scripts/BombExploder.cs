using System.Collections.Generic;
using UnityEngine;

public class BombExploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    public void Explode(Transform explodeTransform)
    {
        List<Rigidbody> explodableObjects = GetExplodableObjects(explodeTransform);

        foreach (Rigidbody cube in explodableObjects)
            cube.AddExplosionForce(_explodeForce, explodeTransform.position, _explodeRadius);
    }

    private List<Rigidbody> GetExplodableObjects(Transform explodeTransform)
    {
        Collider[] hits = Physics.OverlapSphere(explodeTransform.position, _explodeRadius);
        List<Rigidbody> explodableObjects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody)
                explodableObjects.Add(hit.attachedRigidbody);

        return explodableObjects;
    }
}
