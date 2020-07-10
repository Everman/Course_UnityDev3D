using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", levelLoadDelay);
    }

    void LoadNextScene() {
        SceneManager.LoadScene(1);
    }
}
