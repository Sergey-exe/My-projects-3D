using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;

    public void Explode(Transform explodeTransform)
    {
        List<Rigidbody> explodableObjects = GetExplodableObjects(explodeTransform);

        foreach (Rigidbody cube in explodableObjects)
            cube.AddExplosionForce(cube.GetComponent<Cube>().ExplosionForce, explodeTransform.position, cube.GetComponent<Cube>().ExplosionRadios);
    }

    private List<Rigidbody> GetExplodableObjects(Transform explodeTransform)
    {
        Collider[] hits = Physics.OverlapSphere(explodeTransform.position, _explosionRadius);
        List<Rigidbody> explodableObjects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody)
                if (hit.GetComponent<Cube>())
                    explodableObjects.Add(hit.attachedRigidbody);
          
        return explodableObjects;
    }
}
