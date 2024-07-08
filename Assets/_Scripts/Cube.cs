using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour 
{
    [SerializeField] private CubeDesigner _cubeDesigner;
    [SerializeField] private float _minLifeTime;
    [SerializeField] private float _maxLifeTime;

    private bool _isCollision = false;
    public event UnityAction<Cube> IsCollision;

    private void Awake()
    {
        if(_minLifeTime > _maxLifeTime)
            _maxLifeTime = _minLifeTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isCollision == false)
        {
            if (other.GetComponent<Floor>())
            {
                float lifeTimeSeconds = Random.Range(_minLifeTime, _maxLifeTime);

                _isCollision = true;
                _cubeDesigner.ChangeColor();
                StartCoroutine(InvokeCollision(lifeTimeSeconds));
            }
        }
    }

    public void ResetCube()
    {
        _isCollision = false;
        _cubeDesigner.ResetMaterial();
    }

    private IEnumerator InvokeCollision(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        yield return wait;

        IsCollision?.Invoke(this);
    }
}
