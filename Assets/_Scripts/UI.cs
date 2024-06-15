using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.Destroyed += ChangeText;
    }

    private void OnDisable()
    {
        _spawner.Destroyed -= ChangeText;
    }

    public void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
