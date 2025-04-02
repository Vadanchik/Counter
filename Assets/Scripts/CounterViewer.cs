using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += DisplayValue;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= DisplayValue;
    }

    private void DisplayValue()
    {
        float value = _counter.Value;
        _counterText.text = value.ToString();
    }
}
