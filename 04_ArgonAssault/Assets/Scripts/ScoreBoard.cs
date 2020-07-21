using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))] // Requires a Text Component on the GameObject where this script is attached to
public class ScoreBoard : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>(); if(scoreText == null) { Debug.LogError("Could not find Text object in ScoreBoard class"); }
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scoreIncrease) {
        score += scoreIncrease;
        scoreText.text = score.ToString();
    }
}
