using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.05f;
    [SerializeField] private Slider targetSlider;
    
    private float currentValue = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetSlider.value = Mathf.MoveTowards(targetSlider.value, currentValue, moveSpeed);
    }

    public void UpdateTargetValue(float newValue)
    {
        currentValue = newValue;
    }
}
