using DG.Tweening;
using UnityEngine;

public class ScaleChanger : DOTweenAnimator
{
    [SerializeField] private Vector3 _to;

    private void Start()
    {
        transform.DOScale(_to, Duration).SetLoops(Repeats, LoopType);
    }
}
