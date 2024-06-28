using TMPro;
using UnityEngine;

public class InternetChecker : MonoBehaviour
{
    public TMP_Text message;
    private void Start()
    {
        IsInternetAvailable();
    }
    public bool IsInternetAvailable()
    {
        // Check if there is an internet connection available
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // No internet connection
            message.text=("Internet is not reachable.");
            return false;
        }
        else
        {
            // Internet connection is available
            message.text = ("Internet is reachable.");
            return true;
        }
    }
}
