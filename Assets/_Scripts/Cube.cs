using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _fissionProbability = 100;

    public event UnityAction<Cube> CubeClicked;

    public int FissionProbability => _fissionProbability;

    private void OnMouseUp()
    {
        CubeClicked?.Invoke(gameObject.GetComponent<Cube>());
        
    }

    public void ReducingProbability()
    {
        int delimiter = 2;
        _fissionProbability /= delimiter;
    }

    public void ReducingScale()
    {
        int delimiter = 2;
        transform.localScale /= delimiter;
    }
}
