using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : DOTweenAnimator
{
    [SerializeField] private string _textForChange1;
    [SerializeField] private string _textForChange2;
    [SerializeField] private string _textForChange3;
    [SerializeField] private Text _text;

    private void Start()
    {
        Sequence sequenceChangeText = DOTween.Sequence();

        sequenceChangeText.Append(_text.DOText(_textForChange1, Delay).SetLoops(Repeats, LoopType).SetDelay(Delay));
        sequenceChangeText.Append(_text.DOText(_textForChange2, Delay, true, ScrambleMode.All).SetDelay(Delay));
        sequenceChangeText.Append(_text.DOText(_textForChange3, Delay).SetRelative().SetLoops(Repeats, LoopType).SetDelay(Delay));
    }
}
