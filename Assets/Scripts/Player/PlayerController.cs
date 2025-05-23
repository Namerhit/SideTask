using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private Camera _mainCamera;
    
    private Rigidbody _rb;
    private Animator _animator;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        var inputDirection = new Vector3(horizontalInput, 0f, verticalInput);

        if (inputDirection.magnitude > 0.01f)
        {

            var movementDirection = inputDirection.normalized;

            _rb.velocity = new Vector3(movementDirection.x * speed, _rb.velocity.y, movementDirection.z * speed);

            var movementRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), 5 * Time.deltaTime);
            
            _rb.MoveRotation(movementRotation);

            _animator.SetInteger("MovementDirection", 1);
        }

        else
        {
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
            _animator.SetInteger("MovementDirection", 0);
        }

        _mainCamera.transform.position = transform.position + _offset;
    }
}
