using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;

    private void Awake()
    {
        var instanceCount = FindObjectsOfType<ScoreKeeper>().Length;
        if (instanceCount > 1)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
    }
}
