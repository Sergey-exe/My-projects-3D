using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    public event UnityAction<Cube> Clicked;

    [field: SerializeField] public int FissionProbability { get; private set; }

    [field: SerializeField] public int ExplosionForce { get; private set; }

    [field: SerializeField] public int ExplosionRadios { get; private set; }


    private void OnMouseUp()
    {
        Clicked?.Invoke(this);
    }

    public Rigidbody Init()
    {
        ReduceProbability();
        ReduceScale();
        IncreaseExplosionForce();
        IncreaseExplosionRadios();

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

    public void IncreaseExplosionForce()
    {
        int factor = 2;
        ExplosionForce *= factor;
    }

    public void IncreaseExplosionRadios()
    {
        int factor = 2;
        ExplosionRadios *= factor;
    }
}
