using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private MouseClick _input;

    public event Action ValueChanged;

    private int _currentCount;
    private Coroutine _countCoroutine;
    private bool _isCount = false;

    public int Value => _currentCount;

    private void ToogleCount()
    {
        if (_isCount)
        {
            _isCount = false;
            StopCoroutine(_countCoroutine);
        }
        else
        {
            _isCount = true;
            _countCoroutine = StartCoroutine(Count());
        }
    }

    private IEnumerator Count()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isCount)
        {
            yield return wait;

            _currentCount++;
            ValueChanged?.Invoke();
        }
    }

    private void OnEnable()
    {
        _input.OnClick += ToogleCount;
    }

    private void OnDisable()
    {
        _input.OnClick -= ToogleCount;
    }
}
