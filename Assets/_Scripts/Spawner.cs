using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    private int _countDestroyedCubs;

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
        _countDestroyedCubs++;
        Destroyed?.Invoke(_countDestroyedCubs);
    }
}
