using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDesigner : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    [SerializeField] private List<Material> _materials;

    private void Awake()
    {
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        int indexMaterial = Random.Range(0, _materials.Count);

        _renderer.sharedMaterial = _materials[indexMaterial];
    }
}
