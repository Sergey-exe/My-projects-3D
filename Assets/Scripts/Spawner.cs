using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField, Min(0.5f)] private float _delay = 1;

    public Transform[] Waypoint => _waypoints;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), _delay, _delay);
    }

    private void SpawnEnemies()
    {
        int indexSpawn = Random.Range(0, _enemies.Count);

        _enemies[indexSpawn].SetWaypoint(Waypoint);

        Instantiate(_enemies[indexSpawn], transform.position, transform.rotation);
    }
}
