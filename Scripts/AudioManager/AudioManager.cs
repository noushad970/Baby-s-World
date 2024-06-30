using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject BGMusic;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playBgMusic());
    }
    IEnumerator playBgMusic()
    {
        BGMusic.SetActive(false);
        yield return new WaitForSeconds(2);
        BGMusic.SetActive(true);
    }
}
