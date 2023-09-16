using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MainMenu
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper _scoreKeeper;
    private AudioPlayer _audioPlayer;
    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreText.text = "You Scored: " + _scoreKeeper.GetScore();
    }

    public new void NewGame()
    {
        _scoreKeeper.SetScore(0);
        Destroy(_audioPlayer.gameObject);
        base.NewGame();
    }
}
