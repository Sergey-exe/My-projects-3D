using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

<<<<<<< HEAD
    [SerializeField] private int _currentWaypoint = 0;
=======
    public event Action CurrentWaypoint;

    private int _currentWaypoint = 0;
    public bool LastPoint => _currentWaypoint + 1 == _waypoints.Length - 1;
>>>>>>> 961dd60f91a4dce4d8bec2225feae87162209fbf

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