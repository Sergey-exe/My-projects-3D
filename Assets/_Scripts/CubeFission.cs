using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class CubeFission : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CubeExplosion _cubeExplosion;
    [SerializeField] private int _maxFissionProbability = 100;

    private void Start()
    {
        Cube startCube = _spawner.CreateCube(_prefab);
        startCube.CubeClicked += Fission;
    }

    public void Fission(Cube cube)
    {
        int resultingRandomNumber = Random.Range(0, _maxFissionProbability);
        cube.CubeClicked -= Fission;

        if (resultingRandomNumber <= cube.FissionProbability) 
            CreateCubes(cube);
    }


    private void CreateCubes(Cube cube)
    {
        List<Rigidbody> newCubes = new List<Rigidbody>();

        int minCountCubes = 2;
        int maxCountCubes = 7;
        int resultingRandomNumber = Random.Range(minCountCubes, maxCountCubes);

        for (int i = 0; i < resultingRandomNumber; i++)
        {
            Cube newCube = _spawner.CreateCube(cube);
            newCube.ReducingScale();
            newCube.CubeClicked += Fission;
            newCube.ReducingProbability();
            newCubes.Add(newCube.GetComponent<Rigidbody>());
        }

        _cubeExplosion.Explode(newCubes, cube.transform);
    }
}
