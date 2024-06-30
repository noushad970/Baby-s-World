using UnityEngine;
using UnityEngine.UI;

public class ScrollToImageBar : MonoBehaviour
{
    public RectTransform targetImageBar; // Assign your target image bar's RectTransform to this field in the Inspector
    public float scrollSpeed = 5f; // Adjust the scroll speed as needed

    public void ScrollToTarget()
    {
        // Get the current position of the scroll view (assuming ScrollView is the parent of your image bars)
        ScrollRect scrollView = GetComponentInParent<ScrollRect>();
        if (scrollView != null && targetImageBar != null)
        {
            // Calculate the target position to scroll to
            float targetPosX = targetImageBar.localPosition.x;

            // Smoothly scroll to the target position
            Vector2 newScrollPos = new Vector2(targetPosX, scrollView.normalizedPosition.y);
            scrollView.normalizedPosition = Vector2.Lerp(scrollView.normalizedPosition, newScrollPos, Time.deltaTime * scrollSpeed);
        }
    }
}
