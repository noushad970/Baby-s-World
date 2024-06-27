using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour,IDragHandler,IEndDragHandler
{
    private Vector3 panelLocation;
    public float easing = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float difference=eventData.pressPosition.x-eventData.position.x;
        transform.position= panelLocation-new Vector3(difference,0,0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        panelLocation = transform.position;
    }
    IEnumerator smoothMove(Vector3 startpos, Vector3 endpos,float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
