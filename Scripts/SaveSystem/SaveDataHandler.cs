using UnityEngine;

public static class SaveDataHandler
{
    public static void SetObjectDestroyed(string objectId)
    {
        PlayerPrefs.SetInt(objectId, 1);
        PlayerPrefs.Save();
    }

    public static bool IsObjectDestroyed(string objectId)
    {
        return PlayerPrefs.GetInt(objectId, 0) == 1;
    }

    public static void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
