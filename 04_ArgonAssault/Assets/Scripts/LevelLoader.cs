using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Tooltip("Delay in seconds to transit to Game Scene")][SerializeField] float levelLoadDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", levelLoadDelay);
    }

    void LoadNextScene() {
        SceneManager.LoadScene(1);
    }
}
