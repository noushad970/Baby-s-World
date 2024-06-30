using UnityEngine;
using UnityEngine.UI;

public class AddChildImage : MonoBehaviour
{
    public GameObject childImagePrefab; // Assign the child image prefab in the Inspector
    public GameObject barImage; // Assign the BarImage GameObject in the Inspector

    public GameObject myGameButton;
    private void Start()
    {
        Instantiate(myGameButton,barImage.transform);
    }
    public void AddImage()
    {
        Instantiate(childImagePrefab, barImage.transform);
    }
}
