using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private float _delay = 7;

    private void Start()
    {
        Invoke(nameof(Remove), _delay);
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
