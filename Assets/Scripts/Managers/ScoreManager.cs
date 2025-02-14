using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    public static ScoreManager inst;

    [SerializeField] private Text scoreText;

    private void Awake()
    {
        inst = this;    
    }

    internal void IncrementScore()
    {
        _score++;
        scoreText.text = "SCORE: " + _score;
    }
}