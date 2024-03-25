using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _number = 0;
    [SerializeField] private float _delay = 0.5f;

    private bool _isCountRun = false;

    public event UnityAction NumberChange;

    public float Number => _number;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _isCountRun = _isCountRun ? false : true;

            if (_isCountRun)
                StartCoroutine(CountNext(_delay));
        }
    }

    private IEnumerator CountNext(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isCountRun)
        {
            _number++;

            if(NumberChange != null)
                NumberChange.Invoke();

            yield return wait;
        }
    }
}
