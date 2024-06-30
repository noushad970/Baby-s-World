using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Images")]
    
    [Header("Buttons")]
    [Header("Panels")]
    //those data should be stored on storage
    [Header("Splash Screen")]
    public GameObject splashScreenImg;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(splashScreen());
        

    }
    
    IEnumerator ScaleYCoroutine(RectTransform rectTransform, float startScale, float endScale, float duration, GameObject panelOjbect)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newYScale = Mathf.Lerp(startScale, endScale, elapsedTime / duration);
            rectTransform.localScale = new Vector3(rectTransform.localScale.x, newYScale, rectTransform.localScale.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        panelOjbect.SetActive(false);
        //Destroy(panelOjbect);
        // Ensure the final scale is set correctly
        rectTransform.localScale = new Vector3(rectTransform.localScale.x, endScale, rectTransform.localScale.z);
        
        
    }
    
    void loadScreen(string s, RectTransform panel, ref int x, GameObject panelOjbect)
    {
        
        if(x>0)
        SceneManager.LoadScene(s);
        if (x == 0)
        {
            
            
            StartCoroutine(ScaleYCoroutine(panel, 1f, 0f, 1f, panelOjbect));
            x++;
        }
    }
    
    IEnumerator splashScreen()
    {
        splashScreenImg.SetActive(true);
        yield return new WaitForSeconds(2f);
        splashScreenImg.SetActive(false);

    }
    public void loadScreenNotDownloadable(string s)
    {
        SceneManager.LoadScene(s);
    }
}
