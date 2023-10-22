using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    CharacterController _charcterController;
    PlayerInput _playerInput;

    [SerializeField] float _speed=5;
    public float _currentSpeed=5;
    [SerializeField] float _sprintSpeed=15;
    [SerializeField] float _rotaionSpeed = 50;
    Vector3 verticalVelocity = new Vector3(0,1,0);
    [SerializeField] float gravity = 15;

    [SerializeField] float JumpHeight = 20;


    [SerializeField] bool isGrounded;

    private void Awake()
    {
        _charcterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

     

    private void Update()
    {
        ApplyGravityAndJump();

        ApplyMovment();

        ApplyRotation();

        isGrounded = _charcterController.isGrounded;
    }

    private void ApplyRotation()
    {
        float rotationX = _playerInput.look.x * _rotaionSpeed;
        transform.Rotate(Vector3.up * rotationX);
    }

    private void ApplyMovment()
    {            
        Vector3 movement = transform.right * +_playerInput.move.normalized.x + transform.forward * _playerInput.move.normalized.y;
        _charcterController.Move((movement * _currentSpeed + verticalVelocity) * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y<-0.5f) {
            Debug.Log(hit.collider.name);
            verticalVelocity.y = -gravity/3;
        }
    }

    void ApplyGravityAndJump() {
        if (!_charcterController.isGrounded)
        {
                
                verticalVelocity.y -= gravity * Time.deltaTime;                          
        }
        else {
            if (_playerInput.jump)
            {
                verticalVelocity.y = JumpHeight;
            }
            else
            {
                verticalVelocity.y = -0.1f;
            }
        }
    }

}

