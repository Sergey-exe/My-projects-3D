using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ChangeText(float number)
    {
        _text.text = number.ToString();
    }
}
