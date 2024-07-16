using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BombDesigner : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _standardMaterial;

    public void Active(int timeToExplosion)
    {
        StartCoroutine(ReduceAlfa(timeToExplosion));
    }

    private IEnumerator ReduceAlfa(int timeToExplosion)
    {
        Material newMaterial = Instantiate(_standardMaterial);
        _meshRenderer.material = newMaterial;
        float alfa = _meshRenderer.material.color.a;
        float alfaMaxVolume = _meshRenderer.material.color.a;
        float speed = alfaMaxVolume / timeToExplosion;

        while (_meshRenderer.material.color.a != 0)
        {
            alfa = Mathf.Lerp(alfa, 0, speed * Time.deltaTime);
            SetAlfa(alfa);

            yield return null;
        }
    }

    private void SetAlfa(float alfa)
    {
        float red = _meshRenderer.material.color.r;
        float green = _meshRenderer.material.color.g;
        float blue = _meshRenderer.material.color.b;
        _meshRenderer.material.color = new Color(red, green, blue, alfa);
    }
}
