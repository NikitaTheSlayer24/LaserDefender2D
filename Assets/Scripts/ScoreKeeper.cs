using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;


    public int GetScore()
    {
        return _score;
    }

    public void ModifyScore(int value)
    {
        _score += value;
        Mathf.Clamp(_score, 0, int.MaxValue);
        Debug.Log(_score);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
