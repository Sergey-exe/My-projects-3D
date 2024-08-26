using DG.Tweening;
using UnityEngine;

public class Rotator : DOTweenAnimator
{
    [SerializeField] private Quaternion _to;

    private void Start()
    {
        transform.DORotateQuaternion(_to, Duration).SetLoops(Repeats, LoopType);
    }
}
