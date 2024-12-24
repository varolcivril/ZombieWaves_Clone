using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private AttackRadius AttackRadius;

    private Coroutine LookCoroutine;

    public int health = 4;
    public int maxHealth = 4;

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    private void Awake()
    {
        AttackRadius.OnAttack += OnAttack;
    }

    private void Start()
    {
        health = maxHealth;
    }
    //private void OnEnable()
    //{
    //    //ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    //    //ExperienceManager.Instance.OnExperienceChangeAction += HandleExperienceChange;
    //}

    //private void OnDisable()
    //{
    //    //ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    //    //ExperienceManager.Instance.OnExperienceChangeAction -= HandleExperienceChange;
    //}
    private void OnAttack(IDamageable Target)
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt(Target.GetTransform()));
    }

    private IEnumerator LookAt(Transform Target)
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * 10;
            yield return null;
        }

        transform.rotation = lookRotation;
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        health = 0;
        OnPlayerDeath?.Invoke();
        gameObject.SetActive(false);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    
}
