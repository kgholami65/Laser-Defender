using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private int healthAmount;
    [SerializeField] private float speed;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    
    private void Update()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Player))
        {
            var playerHealth = other.GetComponent<Health>();
            playerHealth.SetHealth(playerHealth.GetHealth() + healthAmount);
            Destroy(gameObject);
        }
            
    }
}
