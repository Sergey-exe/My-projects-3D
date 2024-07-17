using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private BombSpawner _bombSpawner;

    public override void ActionOnGet(Cube cube)
    {
        cube.ResetCube();
        cube.transform.position = GetRandomPosition();
        base.ActionOnGet(cube);
    }

    public override Cube Create(Vector3 transform)
    {
        Cube cube = base.Create(GetRandomPosition());
        cube.IsCollision += ReleaseT;

        return cube;
    }

    public override void Delete(Cube cube)
    {
        cube.IsCollision -= ReleaseT;

        base.Delete(cube);
    }

    public override void ReleaseT(Cube cube)
    {
        base.ReleaseT(cube);
        _bombSpawner.GetObjectFromPool(cube.transform);
    }
}
