
using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject explosionEffect;
    private bool _isEnemy;
    private Transform _head;
    private void Start()
    {
        _isEnemy = gameObject.CompareTag(Tags.EnemyBullet);
        _head = GetComponentInChildren<Transform>();
        StartCoroutine(DestroyAfterCertainAmountOfTime());
    }
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_isEnemy)
            transform.Translate(Vector2.up * (speed * Time.deltaTime));
        else
            transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }

    private IEnumerator DestroyAfterCertainAmountOfTime()
    {
        yield return new WaitForSecondsRealtime(lifeTime);
        Destroy(gameObject);
    }
    
    public void Explode()
    {
        ParticleSystem instance = Instantiate(explosionEffect, _head.position, Quaternion.identity)
            .GetComponent<ParticleSystem>();
        AudioPlayer.Instance.PlayNormalExplosionSound();
        Destroy(instance.gameObject, instance.main.duration);
    }
}
