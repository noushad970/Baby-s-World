using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class LoadLocalAssetBundle : MonoBehaviour
{
    public string bundleName;
    public TMP_Text message;
    public void LoadAssetBundle()
    {
        string path = Path.Combine(Application.persistentDataPath, bundleName);
        if (File.Exists(path))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(path);
            if (bundle != null)
            {
                message.text=("Asset Bundle loaded successfully.");
                SceneManager.LoadScene(bundleName);
            }
            else
            {
                message.text = ("Failed to load Asset Bundle.");
            }
        }
        else
        {
            message.text = ("Asset Bundle not found locally.");
        }
    }
}
