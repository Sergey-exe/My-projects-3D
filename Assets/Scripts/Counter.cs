using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0)] private float _number = 0;
    [SerializeField, Min(0.1f)] private float _delay = 0.5f;

    public event UnityAction NumberChange;

    private bool _isCountRun = false;

    private Coroutine _coroutine;

    public float Number => _number;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _isCountRun = _isCountRun ? false : true;

            if (_isCountRun)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine(CounterNumber(_delay));
            }
        }
    }

    private IEnumerator CounterNumber(float delay)
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
