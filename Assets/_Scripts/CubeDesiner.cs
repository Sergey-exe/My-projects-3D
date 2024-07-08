using UnityEngine;

public class CubeDesigner: MonoBehaviour
{
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material[] _materials;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor()
    {
        _meshRenderer.material = _materials[Random.Range(0, _materials.Length)];
    }

    public void ResetMaterial()
    {
        _meshRenderer.material = _startMaterial;
    }
}
