using DG.Tweening;
using UnityEngine;

public class ColorChanger : DOTweenAnimator
{
    [SerializeField] private Color _to;
    [SerializeField] private MeshRenderer _renderer;

    private void Start()
    {
        _renderer.material.DOColor(_to, Duration).SetLoops(Repeats, LoopType);
    }
}
