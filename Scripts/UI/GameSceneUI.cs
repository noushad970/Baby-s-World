using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    public GameObject splashScreenImg;
    private void Start()
    {
        StartCoroutine(splashScreen());
    }
    IEnumerator splashScreen()
    {
        splashScreenImg.SetActive(true);
        yield return new WaitForSeconds(2f);
        splashScreenImg.SetActive(false);

    }
    public void loadmainScene()
    {
        AssetBundleDownloader.instance.GoToMainMenu();
    }
}
