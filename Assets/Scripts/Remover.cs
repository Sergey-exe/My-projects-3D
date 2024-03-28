using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class Remover : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = gameObject.GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.CurrentWaypoint += Remove;
    }

    private void OnDisable()
    {
        _enemy.CurrentWaypoint -= Remove;
    }

    private void Remove()
    {
        if(_enemy.LastPoint)
            Destroy(gameObject);
    }
}
