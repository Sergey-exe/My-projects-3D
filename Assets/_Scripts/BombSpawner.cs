using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;
    [SerializeField] private BombExploder _exploder;
    [SerializeField] private int _maxTimeToExplode;
    [SerializeField] private int _minTimeToExplode;

    private void Awake()
    {
        if(_minTimeToExplode > _maxTimeToExplode)
            _minTimeToExplode = _maxTimeToExplode;
    }

    public void Spawn(Transform spawnPosition)
    {
        int timeExplode = Random.Range(_minTimeToExplode, _maxTimeToExplode);
        Bomb bomb = Instantiate(_prefab, spawnPosition.position, spawnPosition.rotation);
        bomb.Active(timeExplode);
        bomb.Explode += Explode;
    }

    private void Explode(Bomb bomb)
    {
        _exploder.Explode(bomb.transform);
        Destroy(bomb.gameObject);
    }
}
