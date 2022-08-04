using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class HoleController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private int speed=2 ;
    
    void Start()
    {
        _playerInput = gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2 input = _playerInput.actions["Movement"].ReadValue<Vector2>();
        Vector3 move = new Vector3(-input.x, 0, -input.y);
        Vector3 newPosition = transform.position + move * Time.deltaTime * speed;
        
        transform.DOMove(newPosition, Time.deltaTime);
        
        
        
      //  Vector3 targetPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
       // transform.DOMove(targetPosition, 3f);
    }
}
