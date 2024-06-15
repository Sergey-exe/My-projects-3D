using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    private int CountDestroyedCubs;

    public event UnityAction<int> Destroyed;

    public Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(cube);
        newCube.Clicked += DestroyCube;

        return newCube;
    }

    private void DestroyCube(Cube cube)
    {
        cube.Clicked -= DestroyCube;
        Destroy(cube.gameObject);
        CountDestroyedCubs++;
        Destroyed?.Invoke(CountDestroyedCubs);
    }
}
