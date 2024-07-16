using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] public BombDesigner _bombDesigner;

    public event UnityAction<Bomb> Explode;

    public void Active(int timeToExplosion)
    {
        _bombDesigner.Active(timeToExplosion);
        StartCoroutine(CountdownToExplosion(timeToExplosion));
    }

    private IEnumerator CountdownToExplosion(int timeToExplosion)
    {
        WaitForSeconds wait = new WaitForSeconds(timeToExplosion);

        yield return wait;

        Explode?.Invoke(this);
    }
}
