using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    

    public void loadmainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
