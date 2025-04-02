using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputService _input;

    public event Action<float> ValueChanged;

    private int _currentCount;
    private Coroutine _countCoroutine;

    private void OnEnable()
    {
        _input.OnClick += ToogleCount;
    }

    private void OnDisable()
    {
        _input.OnClick -= ToogleCount;
    }

    private void ToogleCount()
    {
        if (_countCoroutine == null)
        {
            _countCoroutine = StartCoroutine(Count());
        }
        else
        {
            StopCoroutine(_countCoroutine);
            _countCoroutine = null;
        }
    }

    private IEnumerator Count()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            _currentCount++;
            ValueChanged?.Invoke(_currentCount);
        }
    }
}
