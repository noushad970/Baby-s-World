using System;
using System.Collections;
using System.IO;
using Renci.SshNet;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssetBundleDownloader : MonoBehaviour
{
    public static AssetBundleDownloader instance;
    private string host;
    private string username ;
    private string password ;
    private string remoteFilePath;
    private string localFilePath ;
    public TMP_Text message;
    public GameObject buttonDownload;
    int x = 0;

    public RectTransform targetRectTransform;
    private AssetBundle loadedAssetBundle;
    private void Awake()
    {
        instance = this;
       host = "167.71.255.38";
    username = "game";
   password = "Morgame@123";
    remoteFilePath = "/public_html/AssetBundles/game2";
     localFilePath = Application.persistentDataPath + "/assetbundle";
}
    public void AssetBundleDownloaders()
    {
        try
        {
            StartResizeAnimation(3);
            using (var sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();
                using (var fileStream = File.OpenWrite(localFilePath))
                {
                    sftp.DownloadFile(remoteFilePath, fileStream);
                }
                sftp.Disconnect();
            }
            x++;
            ObjectDestroyer.Instance.DestroyObject();
            message.text = ("Download completed!");
           // LoadAssetBundle();
        }
        catch (Exception ex)
        {
            message.text = ("Error downloading file: " + ex.Message);
        }
    }

    public void LoadAssetBundle()
    {
        StartCoroutine(LoadAssetBundleCoroutine());
    }

    private IEnumerator LoadAssetBundleCoroutine()
    {
        var bundleLoadRequest = AssetBundle.LoadFromFileAsync(localFilePath);

        yield return bundleLoadRequest;
        loadedAssetBundle = bundleLoadRequest.assetBundle;

        AssetBundle assetBundle = bundleLoadRequest.assetBundle;

        if (assetBundle != null)
        {
            string[] scenePaths = assetBundle.GetAllScenePaths();
            string sceneName = Path.GetFileNameWithoutExtension(scenePaths[0]);
            SceneManager.LoadScene(sceneName);
            message.text = ("load Scene!");
        }
        else
        {
            message.text = ("Failed to load AssetBundle!");
        }
    }
    public void GoToMainMenu()
    {
        if (loadedAssetBundle != null)
        {
            Debug.Log("Unloading AssetBundle before returning to main menu");
            loadedAssetBundle.Unload(true);
            loadedAssetBundle = null;
        }
        SceneManager.LoadScene("MainMenu");
    }

    //

    public void StartResizeAnimation(float duration)
    {
            StartCoroutine(ResizeCoroutine(duration));
           
        
    }

    private IEnumerator ResizeCoroutine(float duration)
    {
        Vector2 mainsize;
        Vector2 originalSize = targetRectTransform.sizeDelta;
        mainsize = originalSize;
        Vector2 targetSize = Vector2.zero;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpolate the size
            targetRectTransform.sizeDelta = Vector2.Lerp(originalSize, targetSize, t);

            yield return null;
        }

        // Ensure the final size is set to target size
        targetRectTransform.sizeDelta = targetSize;
        originalSize = mainsize;
    }


}
