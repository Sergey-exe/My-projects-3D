using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : DOTweenAnimator
{
    [SerializeField] private string _textForChange1;
    [SerializeField] private string _textForChange2;
    [SerializeField] private string _textForChange3;
    [SerializeField] private float _delay;
    [SerializeField] private Text _text;

    private void Start()
    {
        Sequence sequenceChangeText = DOTween.Sequence();
        sequenceChangeText.SetLoops(Repeats, LoopType);
        sequenceChangeText.Append(_text.DOText(_textForChange1, _delay));
        sequenceChangeText.Append(_text.DOText(_textForChange2, _delay, true, ScrambleMode.All));
        sequenceChangeText.Append(_text.DOText(_textForChange3, _delay).SetRelative());
    }
}
