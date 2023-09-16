
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class Health : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int health;
    [SerializeField] private GameObject explosionEffect;

    [Header("AI")] [SerializeField] private int score;
    [SerializeField] [Range(0, 5)] private int healthIncreaseChance;
    [SerializeField] private GameObject healthIncreasePrefab;

    private CameraShake _cameraShake;
    private ScoreKeeper _scoreKeeper;
    private LevelManager _levelManager;
    private int _maximumHealth;

    private void Awake()
    {
        _maximumHealth = health;
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (Camera.main != null)
        {
            _cameraShake = Camera.main.GetComponent<CameraShake>();
            if (_cameraShake == null)
                Debug.Log("no camera shake script is attached to the main camera");
        }
        else
            Debug.Log("no main camera available");

        _levelManager = FindObjectOfType<LevelManager>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Enemy) || other.CompareTag(Tags.PlayerBullet) || other.CompareTag(Tags.EnemyBullet))
        {
            var damageDealer = other.GetComponent<DamageDealer>();
            if (other.CompareTag(Tags.Enemy))
                Explode();
            else
                other.GetComponent<Laser>().Explode();
            if (damageDealer != null)
            {
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        if (gameObject.CompareTag(Tags.Enemy))
        {
            _scoreKeeper.SetScore(_scoreKeeper.GetScore() + score);
            int healthDrop = Random.Range(0, 5);
            if (healthDrop <= healthIncreaseChance)
                Instantiate(healthIncreasePrefab, transform.position, Quaternion.identity);
        }
        else if (gameObject.CompareTag(Tags.Player))
            _levelManager.GameOver();

        _cameraShake.StartShaking();
        Destroy(gameObject);
    }

    private void Explode()
    {
        var instance = Instantiate(explosionEffect, transform.position, Quaternion.identity)
            .GetComponent<ParticleSystem>();
        AudioPlayer.Instance.PlayNormalExplosionSound();
        Destroy(instance, instance.main.duration);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetHealth(int healthValue)
    {
        if (healthValue <= _maximumHealth)
            health = healthValue;
        else
            health = _maximumHealth;
        
    }
}
