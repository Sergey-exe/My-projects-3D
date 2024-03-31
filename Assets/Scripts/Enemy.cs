using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    [SerializeField] private int _currentWaypoint = 0;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1);

            if (_currentWaypoint == _waypoints.Length)
                Destroy(gameObject);
        }

        if(_currentWaypoint >= _waypoints.Length)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    public void SetWaypoint(Transform[] waypoints)
    {
        _waypoints = waypoints;
    }
}