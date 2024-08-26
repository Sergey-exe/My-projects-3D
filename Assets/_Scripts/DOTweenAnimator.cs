using DG.Tweening;
using UnityEngine;

public class DOTweenAnimator : MonoBehaviour
{
    [field: SerializeField] public int Repeats { get; private set; }

    [field: SerializeField] public float Duration { get; private set; }

    [field: SerializeField] public LoopType LoopType { get; private set; }
}
