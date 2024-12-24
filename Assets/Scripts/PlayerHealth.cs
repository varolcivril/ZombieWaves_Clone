using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public int health, maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        
        
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
        {
            health = 0;

            //dead
            //game over
            OnPlayerDeath?.Invoke();
        }
    }
}
