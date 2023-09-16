using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class GameScreenUI : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider healthBarSlider;
    private ScoreKeeper _scoreKeeper;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthBarSlider.maxValue = playerHealth.GetHealth();
        healthBarSlider.minValue = 0;
        scoreText.text = _scoreKeeper.GetScore().ToString();
        healthBarSlider.value = playerHealth.GetHealth();
    }
    
    void Update()
    {
        scoreText.text = _scoreKeeper.GetScore().ToString();
        healthBarSlider.value = playerHealth.GetHealth();
    }
}
