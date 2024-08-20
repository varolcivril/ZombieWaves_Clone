using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public int health, maxHealth;

    [SerializeField] private Animator animator;


    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        OnPlayerDamaged?.Invoke();
        //animator.SetBool("IsDead", true);

        if (health <= 0)
        {
            health = 0;
            //dead
            //game over
            OnPlayerDeath?.Invoke();
        }
    }
}
