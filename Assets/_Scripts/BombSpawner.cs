using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] BombExploder _exploder;

    public override void ActionOnGet(Bomb bomb)
    {
        bomb.ResetBomb();
        base.ActionOnGet(bomb);
    }

    public override Bomb Create(Vector3 vector3)
    {
        Bomb bomb = base.Create(vector3);
        bomb.Active(LifeTimeSeconds);
        bomb.Explode += ReleaseT;
        bomb.Explode += Explode;

        return bomb;
    }

    public override void Delete(Bomb bomb)
    {
        bomb.Explode -= ReleaseT;
        bomb.Explode -= Explode;

        base.Delete(bomb);
    }

    private void Explode(Bomb bomb)
    {
        _exploder.Explode(bomb.transform);
    }
}
