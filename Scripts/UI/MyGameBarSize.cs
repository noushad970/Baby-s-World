using UnityEngine;

public class MyGameBarSize : MonoBehaviour
{
    public RectTransform sourceImage; // Reference to the RectTransform of the source image

    private RectTransform targetRectTransform;

    private void Awake()
    {
        targetRectTransform = GetComponent<RectTransform>();

    }

    private void Update()
    {
        SyncSize();
    }

    private void SyncSize()
    {
        if (sourceImage != null)
        {
            targetRectTransform.sizeDelta = sourceImage.sizeDelta;
        }
    }
}
