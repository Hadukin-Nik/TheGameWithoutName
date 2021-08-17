using System;
using System.Collections;
using System.Collections.Generic;
using Code.Real.World.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class Walker : MonoBehaviour, ISpeed
{

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

        
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector2 _moveDir;
    
    
    private float _horizonalMove = 0f;
    private float _verticalMove = 0f;
    private float _timeForDebuf = 0f;
    
    private bool _fly = true;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    
    void Update()
    {
        _timeForDebuf -= _timeForDebuf > 0.0f ? Time.deltaTime : 0;
        
        _horizonalMove = Input.GetAxisRaw("Horizontal");
        
        _animator.SetFloat("Speed", _horizonalMove);
        
        _moveDir = new Vector2(_horizonalMove, 0).normalized;
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = _moveDir * _speed;

        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetKey(KeyCode.Space))
        {
            
            if (_fly == false)
            {
                Debug.Log("fly");
                _rigidbody2D.AddForce(transform.up* _jumpForce, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(((1<<other.gameObject.layer) & _groundLayer) != 0)
        {
            _fly = false;
        }
        Debug.Log("OnCollisionEnter");
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if(((1<<other.gameObject.layer) & _groundLayer) != 0)
        {
            _fly = true;
        }
        Debug.Log("OnCollisionExit");
    }


    public void Speed(float count)
    {
        Debug.Log("Speed" + count);
        _speed += count;
    }
}
