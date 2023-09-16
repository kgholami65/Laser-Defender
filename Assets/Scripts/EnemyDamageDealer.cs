using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : DamageDealer
{
    private ScoreKeeper _scoreKeeper;
    private CameraShake _cameraShake;
    private void Start()
    {
        _cameraShake = FindObjectOfType<CameraShake>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public override void Hit()
    {
        _scoreKeeper.SetScore(_scoreKeeper.GetScore() + gameObject.GetComponent<Health>().GetScore());
                _cameraShake.StartShaking();
        Destroy(gameObject);
    }
    
}
