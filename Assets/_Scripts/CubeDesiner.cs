using UnityEngine;

public class CubeDesigner: MonoBehaviour
{
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material[] _materials;

    public void ChangeColor()
    {
        GetComponent<MeshRenderer>().material = _materials[Random.Range(0, _materials.Length)];
    }

    public void ResetMaterial()
    {
        GetComponent<MeshRenderer>().material = _startMaterial;
    }
}
