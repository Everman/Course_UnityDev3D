using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))] // Requires a Text Component on the GameObject where this script is attached to
public class ScoreBoard : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;

    [Tooltip("Amount of points awarded when calling the ScoreHit function")] [SerializeField] int pointsPerHit = 10;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>(); if(scoreText == null) { Debug.LogError("Could not find Text object in ScoreBoard class"); }
        scoreText.text = score.ToString();
    }

    public void ScoreHit() {
        score += pointsPerHit;
        scoreText.text = score.ToString();
    }
}
