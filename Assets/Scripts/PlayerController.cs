using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rb;
    private Animator _animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _rb.freezeRotation = true;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = Vector3.zero;
        int movementDirection = 0;

        if (verticalInput > 0)
        {
            movement.z = 1;
            movementDirection = 1;
        }
        else if(verticalInput < 0)
        {
            movement.z = -1;
            movementDirection = 2;
        }
        else if(horizontalInput > 0)
        {
            movement.x = 1;
            movementDirection = 3;
        }
        else if (horizontalInput < 0)
        {
            movement.x = -1;
            movementDirection = 4;
        }

        Vector3 currentVelocity = speed * movement;
        currentVelocity.y = _rb.velocity.y;
        _rb.velocity = currentVelocity;
        
        _animator.SetInteger("MovementDirection", movementDirection);
    }
}
