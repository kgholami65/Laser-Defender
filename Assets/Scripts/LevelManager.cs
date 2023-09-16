using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseCanvas;

    [SerializeField] private Canvas optionsCanvas;

    private ScoreKeeper _scoreKeeper;
    private AudioPlayer _audioPlayer;
    void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void PauseGame()
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameOver");
    }

    public void NewGame()
    {
        _scoreKeeper.SetScore(0);
        Time.timeScale = 1;
        Destroy(_audioPlayer.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Options()
    {
        pauseCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(true);
    }
}
