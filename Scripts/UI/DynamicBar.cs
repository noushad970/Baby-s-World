using UnityEngine;
using UnityEngine.UI;

public class DynamicBar : MonoBehaviour
{
    public float childImageWidth = 100f; // Width of each child image
    public float padding = 10f; // Padding between child images

    private RectTransform rectTransform;
    private GridLayoutGroup gridLayoutGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }
   

    private void Update()
    {
        AdjustBarLength();
    }

    private void AdjustBarLength()
    {
        int childCount = transform.childCount;
        int rows = Mathf.CeilToInt(childCount / 2f); // Calculate the number of rows
        float newWidth = (childImageWidth + padding) * rows - padding; // Calculate the new width
        rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y);
    }
}
