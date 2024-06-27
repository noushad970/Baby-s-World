using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Images")]
    public Image gameButton2DownloadSliderImage;
    public Image gameButton3DownloadSliderImage;

    [Header("Buttons")]
    public Button Gameplay1Button;
    public Button Gameplay2Button;
    public Button Gameplay3Button;
    public Button Gameplay4Button;
    [Header("Panels")]
    public RectTransform panel2;
    public RectTransform panel3;
    [Header("Panel Gameobject")]
    public GameObject panel2GameObject;
    public GameObject panel3GameObject;
    //those data should be stored on storage
    [Header("Storable Data")]
    public static int x2,x3;
    private void Awake()
    {
        if (x2 > 0)
        {
            panel2GameObject.SetActive(false);
        }
        if (x3 > 0)
        {
            panel3GameObject.SetActive(false);
        }
    }
    void Start()
    {
        //DontDestroyOnLoad(this);
        if (gameButton2DownloadSliderImage == null)
        {
            gameButton2DownloadSliderImage = GetComponent<Image>();
        }
        if(x2>0)
            panel2GameObject.SetActive(false);

        if (x3 > 0)
            panel3GameObject.SetActive(false);
        Gameplay1Button.onClick.AddListener(() =>
        loadScreenNotDownloadable("Game1"));

        Gameplay2Button.onClick.AddListener(() =>
        loadScreen("Game2", panel2,ref x2, panel2GameObject));

        Gameplay3Button.onClick.AddListener(() =>
        loadScreen("Game3",panel3,ref x3, panel3GameObject));
        Gameplay4Button.onClick.AddListener(() =>
        Application.Quit());

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

    void loadScreenNotDownloadable(string s)
    {
        SceneManager.LoadScene(s);
    }
}
