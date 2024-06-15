using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    [field: SerializeField] public int FissionProbability { get; private set; }

    public event UnityAction<Cube> Clicked;

    private void OnMouseUp()
    {
        Clicked?.Invoke(this);
    }

    public Rigidbody Init()
    {
        ReduceProbability();
        ReduceScale();

        return GetComponent<Rigidbody>();
    }

    public void ReduceProbability()
    {
        int delimiter = 2;
        FissionProbability /= delimiter;
    }

    public void ReduceScale()
    {
        int delimiter = 2;
        transform.localScale /= delimiter;
    }
}
