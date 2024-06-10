using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(cube);
        newCube.CubeClicked += DestroyCube;

        return newCube;
    }

    private void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
