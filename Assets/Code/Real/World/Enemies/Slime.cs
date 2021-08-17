using System;
using System.Collections.Generic;
using Code.Real.World.Enemies;
using UnityEngine;

using static UnityEngine.Debug;
public sealed class Slime : MonoBehaviour, IDisposable, IDamage
{ 
    [SerializeField] private GameObject _ghostSlimes;
    
    [SerializeField] private float _health;
    [SerializeField] private float _maxDixtanceForGhosts;
    [SerializeField] private float _speed;
    [SerializeField] private int _numberOfGhosts; 

    private List<TinySlime> _tinySlimes;
    public void Awake()
    {
        Log(("I am Awake!"));

        _tinySlimes = new List<TinySlime>();
        for (int i = 0; i < _numberOfGhosts; i++)
        { 
            Log(("I am Alive!"));

            _tinySlimes.Add(new TinySlime(_speed, _maxDixtanceForGhosts,Instantiate(_ghostSlimes), gameObject));
        }
    }
    
    public void Update()
    {
        foreach (var slimeGhost in _tinySlimes)
        {
            slimeGhost.Check();
        }
    }

    public void Dispose()
    {
        foreach (var slimeGhost in _tinySlimes)
        {
            Destroy(slimeGhost.SlimeObject);
        }
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        _health -= damage;
        if (_health <= 0.0f)
        {
            Dispose();
        }
    }
}


