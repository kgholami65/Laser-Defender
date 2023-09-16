using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform head;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject laserPrefab;

    [Header("AI")] [SerializeField] private float fireRateVariance;
    [SerializeField] private float minimumFireRate;
    
    private bool isFiring;
    private Coroutine _firingCoroutine;
    

    void Start()
    {
        if (gameObject.CompareTag(Tags.Enemy))
            isFiring = true;
    }
    
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (isFiring && _firingCoroutine == null)
            _firingCoroutine = StartCoroutine(StartShooting());
        else if (!isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    private void OnFire(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }

    private IEnumerator StartShooting()
    {
        if (gameObject.CompareTag(Tags.Player))
            while (true)
            {
                Instantiate(laserPrefab, head.position, Quaternion.identity);
                AudioPlayer.Instance.PlayPlayerShootSound();
                yield return new WaitForSecondsRealtime(fireRate);
            }
        
        if (gameObject.CompareTag(Tags.Enemy))
            while (true)
            {
                Instantiate(laserPrefab, transform.position, Quaternion.identity);
                AudioPlayer.Instance.PlayEnemyShootSound();
                yield return new WaitForSecondsRealtime(GetRandomFireRates());
            }
    }
    
    private float GetRandomFireRates()
    {
        var randomFireRate = Random.Range(fireRate - fireRateVariance, fireRate + fireRateVariance);
        return Mathf.Clamp(randomFireRate, minimumFireRate, float.MaxValue);
    }
}
