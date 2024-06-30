using UnityEngine;
using UnityEngine.UI;
//this script will add with UI Content Gameobject
public class ChangePanelPosition : MonoBehaviour
{
    public RectTransform featureBarPos;
    public RectTransform TodaysPickBarPos;
    public RectTransform PopularBarPos;

    RectTransform rectTransform;

    //p/ublic float newXPosition = 100f; // Set the new x-axis position here

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();  
    }

    public void MoveRectToFeature()
    {
        // Change the x-axis position of the RectTransform
        Vector3 newPosition = rectTransform.localPosition;
        Vector3 featurepos= featureBarPos.localPosition;
        newPosition.x = (-featurepos.x) +60;
        rectTransform.localPosition = newPosition;
    }
    public void MoveRectToTodaysPick()
    {
        // Change the x-axis position of the RectTransform
        Vector3 newPosition = rectTransform.localPosition;
        Vector3 targetPos = TodaysPickBarPos.localPosition;
        newPosition.x = (-targetPos.x) + 70;
        rectTransform.localPosition = newPosition;
    }
    public void MoveRectToPopular()
    {
        // Change the x-axis position of the RectTransform
        Vector3 newPosition = rectTransform.localPosition;
        Vector3 targetPos = PopularBarPos.localPosition;
        newPosition.x = (-targetPos.x) + 50;
        rectTransform.localPosition = newPosition;
    }
    public void MoveRectToMyGame()
    {
        // Change the x-axis position of the RectTransform
        Vector3 newPosition = rectTransform.localPosition;
        Vector3 targetPos = PopularBarPos.localPosition;
        newPosition.x =  0;
        rectTransform.localPosition = newPosition;
    }

}
