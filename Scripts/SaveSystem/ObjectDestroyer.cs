using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public static ObjectDestroyer Instance;
    [SerializeField] private string objectId;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (SaveDataHandler.IsObjectDestroyed(objectId))
        {
            Destroy(gameObject);
        }
    }

    public void DestroyObject()
    {
        SaveDataHandler.SetObjectDestroyed(objectId);
        Destroy(gameObject);
    }
}
