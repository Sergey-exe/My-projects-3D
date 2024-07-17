using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] public BombDesigner _bombDesigner;

    public event UnityAction<Bomb> Explode;

    public void Active(float timeToExplosion)
    {
        _bombDesigner.Active(timeToExplosion);
        StartCoroutine(CountdownToExplosion(timeToExplosion));
    }

    public void ResetBomb()
    {
        _bombDesigner.ResetMaterial();
    }

    private IEnumerator CountdownToExplosion(float timeToExplosion)
    {
        WaitForSeconds wait = new WaitForSeconds(timeToExplosion);

        yield return wait;

        Explode?.Invoke(this);
    }
}
