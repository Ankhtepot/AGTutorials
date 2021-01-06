using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMover : MonoBehaviour
{
    public RectTransform baseRectTransform;
    
    private float minDistance;
    private float maxDistance;
    private float distance;
    private float spinSpeed = 4;
    private RectTransform rectTransfrom;
    private Vector3 basePosition;
    private Vector3 positionOffset = Vector3.zero;
    
    void Start()
    {
        rectTransfrom = GetComponent<RectTransform>();
        basePosition = baseRectTransform.position;
        minDistance = Screen.height * 0.125f;
        maxDistance = Screen.height * 0.375f;
    }

    void Update()
    {
        distance = Mathf.Lerp(minDistance, maxDistance, Mathf.Cos(Time.time) * 0.5f + 0.5f);
        positionOffset.x = distance * Mathf.Cos(Time.time * spinSpeed);
        positionOffset.y = distance * Mathf.Cos(Time.time * spinSpeed);
        rectTransfrom.position = basePosition + positionOffset;
    }
}
