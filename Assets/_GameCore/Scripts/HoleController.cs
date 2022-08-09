using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class HoleController : MonoBehaviour
{
    private GameManager _gameManager;
    private LevelManager _levelManager;
    
    private PlayerInput _playerInput;
    private int _speed=2 ;
    private int _characterCurrentExp;
    private int _characterLevel;
    
    void Start()
    {
        _gameManager = GameManager.Instance;
        _playerInput = gameObject.GetComponent<PlayerInput>();
    }
    
    void Update()
    {
        Vector2 input = _playerInput.actions["Movement"].ReadValue<Vector2>();
        Vector3 move = new Vector3(-input.x, 0, -input.y);
        Vector3 newPosition = transform.position + move * Time.deltaTime * _speed;
        
        transform.DOMove(newPosition, Time.deltaTime);
    }
}
