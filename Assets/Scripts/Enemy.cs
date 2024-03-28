using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    public event Action CurrentWaypoint;

    private int _currentWaypoint = 0;
    public bool LastPoint => _currentWaypoint + 1 == _waypoints.Length - 1;

    private void Start()
    {

    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
            CurrentWaypoint?.Invoke();
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    public void SetWaypoint(Transform[] waypoints)
    {
        _waypoints = waypoints;
    }
}
