using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _delay;
    [SerializeField] private float _countCubesInSpawn;
    [SerializeField] private float _maxLifeTimeSeconds;
    [SerializeField] private float _minLifeTimeSeconds;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Cube> _cubesPool;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _cubesPool = new ObjectPool<Cube>
        ( 
            createFunc : () => Spawn(),
            actionOnGet : (cube) => ActionOnGet(cube),
            actionOnRelease : (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy : (cube) => DeleteCube(cube),
            collectionCheck : true,
            defaultCapacity : _poolCapacity,
            maxSize : _poolMaxSize
        );
    }

    private void Update()
    {
        if (_spawnCoroutine == null)
            _spawnCoroutine = StartCoroutine(SpawnWithDelay());
    }


    private void ActionOnGet(Cube cube)
    {
        cube.transform.position = GetRandomPosition();
        cube.gameObject.SetActive(true);
        cube.ResetCube();
    }

    private IEnumerator SpawnWithDelay()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _countCubesInSpawn; i++)
            _cubesPool.Get();

        yield return wait;

        _spawnCoroutine = null;
    }

    private Cube Spawn()
    {
        Cube cube = Instantiate(_prefab, GetRandomPosition(), transform.rotation);
        cube.IsCollision += ReleaseCube;

        return cube;
    }

    private Vector3 GetRandomPosition()
    {
        Bounds spawnArea = GetComponent<Collider>().bounds;

        float positionX = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float positionY = Random.Range(spawnArea.min.y, spawnArea.max.y);
        float positionZ = Random.Range(spawnArea.min.z, spawnArea.max.z);

        return new Vector3(positionX, positionY, positionZ);
    }

    private void DeleteCube(Cube cube)
    {
        float lifeTimeSeconds = Random.Range(_minLifeTimeSeconds, _maxLifeTimeSeconds);

        cube.IsCollision -= ReleaseCube;
        Destroy(cube.gameObject, lifeTimeSeconds);
    }

    private void ReleaseCube(Cube cube)
    {
        _cubesPool.Release(cube);
    }
}
