using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour, IDamage, IDisposable
{
    [SerializeField] private float _maxHealth = 10f;

    private float _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Damage(float damage)
    {
        Debug.Log((damage));
        _health -= damage;

        if (_health <= 0.0f)
        {
            Dispose();
        }
    }

    public void Healing(float healthPointToRestore)
    {
        if (healthPointToRestore + _health > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += healthPointToRestore;
        }
    }

    public float HowManyHealthPointsHave => _maxHealth - _health;

    public void Dispose()
    {
        
        Destroy(gameObject);
    }
}
