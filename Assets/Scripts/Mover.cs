using System.Linq;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _storagePoints;

    private Transform[] _points;
    private int _indexRemainingPoints;

    private void Start()
    {
        _points = new Transform[_storagePoints.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _storagePoints.GetChild(i);
    }

    private void Update()
    {
        Transform _currentPoint = _points[_indexRemainingPoints];

        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == _currentPoint.position)
            ChangePoint();
    }

    private void ChangePoint()//Изменения
    {
        _indexRemainingPoints = ++_indexRemainingPoints % _points.Length;

        Vector3 pointVector = _points[_indexRemainingPoints].transform.position;

        transform.forward = pointVector - transform.position;
    }
}
