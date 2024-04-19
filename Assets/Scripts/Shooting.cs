using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _delayShot;

    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;//Изменения

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;

        var wait = new WaitForSeconds(_delayShot);

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            Rigidbody newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speedBullet;

            yield return wait;
        }
    }
}