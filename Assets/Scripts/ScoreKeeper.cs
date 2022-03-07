using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;

    private static ScoreKeeper _instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
