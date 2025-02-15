using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    public static ScoreManager inst;

    [SerializeField] private Text scoreText;
    private PlayerMovementController playerMovement;

    private void Awake()
    {
        inst = this;
        playerMovement = GameObject.FindObjectOfType<PlayerMovementController>();
    }

    internal void IncrementScore()
    {
        _score++;
        scoreText.text = "SCORE: " + _score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
}