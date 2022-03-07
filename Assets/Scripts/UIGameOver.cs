using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private ScoreKeeper _scoreKepeer;

    private void Awake()
    {
        _scoreKepeer = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        scoreText.text = "You Scored: \n" + _scoreKepeer.GetScore().ToString();
    }
}
