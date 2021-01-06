using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReparentUI : MonoBehaviour
{
    [SerializeField] private List<Image> images;
    [SerializeField] private Transform canvasParent;
    [SerializeField] private Transform hideParent;
    [SerializeField] private bool isHidden;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReparentImages()
    {
        isHidden = !isHidden;

        foreach (var image in images)
        {
            image.gameObject.transform.parent = isHidden ? hideParent : canvasParent;
        }
    }
}
