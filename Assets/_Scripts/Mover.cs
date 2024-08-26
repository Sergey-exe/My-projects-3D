using DG.Tweening;
using UnityEngine;

public class Mover : DOTweenAnimator
{
    [SerializeField] private float _to;

    private void Start()
    {
        transform.DOMoveX(_to, Duration).SetLoops(Repeats, LoopType);
    }
}
