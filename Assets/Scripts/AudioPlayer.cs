
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] [SerializeField] private AudioClip playerShootSound;
    [SerializeField] [Range(0f, 1f)] private float playerShootingVolume;
    [SerializeField] private AudioClip enemyShootSound;
    [SerializeField] [Range(0f, 1f)] private float enemyShootSoundVolume;

    [Header("Explosion")] [SerializeField] private AudioClip normalExplosion;
    [SerializeField] [Range(0f, 1f)] private float explosionVolume;
    
    public static AudioPlayer Instance;
    private Camera _camera;

    private void Awake()
    {
        var instanceCount = FindObjectsOfType<AudioPlayer>().Length;
        if (instanceCount > 1)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    public void PlayPlayerShootSound()
    {
        AudioSource.PlayClipAtPoint(playerShootSound, _camera.transform.position, playerShootingVolume);
    }

    public void PlayEnemyShootSound()
    {
        AudioSource.PlayClipAtPoint(enemyShootSound, _camera.transform.position, enemyShootSoundVolume);
    }

    public void PlayNormalExplosionSound()
    {
        AudioSource.PlayClipAtPoint(normalExplosion, _camera.transform.position, explosionVolume);
    }
    
}
