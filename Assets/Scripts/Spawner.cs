using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField, Min(0.5f)] private float _delay = 1;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), _delay, _delay);
    }

    private void SpawnEnemies()
    {
        int indexSpawn = Random.Range(0, _enemies.Count);

        float angleMax = 180;
        float angle = Random.Range(0, angleMax);

        if (_enemies[indexSpawn].GetComponent<Enemy>())
            Instantiate(_enemies[indexSpawn], transform.position, Quaternion.Euler(0, angle, 0));
    }
}
