using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGameButtonScript : MonoBehaviour {
    public void GotoLevel1() {
        SceneManager.LoadScene(1);
    }

    public void GotoMainMenu() {
        SceneManager.LoadScene(0);
    }
}