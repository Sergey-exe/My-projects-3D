using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = "0";
    }

    private void OnEnable()
    {
        _counter.NumberChange += DisplayNumber;
    }

    private void OnDisable()
    {
        _counter.NumberChange -= DisplayNumber;
    }

    private void DisplayNumber()
    {
        _text.text = _counter.Number.ToString();
    }
}
