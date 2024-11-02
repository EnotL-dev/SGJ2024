using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider _output;

    public void UpdateValue(int currentValue, int maxValue)
    {
        if (currentValue >= 0)
            _output.value = (float)currentValue / (float)maxValue;
        else
        {
            _output.value = 0;

        }
        //Debug.Log($"currentValue = {currentValue} | maxValue = {maxValue}");
    }
}
