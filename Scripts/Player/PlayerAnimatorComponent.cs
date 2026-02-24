using System;
using Player;
using UnityEngine;

namespace Player
{
    public class PlayerAnimatorComponent : MonoBehaviour
    {
        private Animator _animator;
        private float _walk;

        private bool _attack;
        private float _attackKick;
        private float _attackDiveKick;
        private float _attackJab;
        private float _attackPunch;
        private float _attackJumpKick;

        private bool _jumped;

        private PlayerMovementComponent _movementComponent;

        private void Awake()
        {
            _movementComponent = GetComponent<PlayerMovementComponent>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Walk();
            _animator.SetFloat("Walk", _walk);

            Attack();
            _animator.SetFloat("Kick", _attackKick);
            _animator.SetFloat("Dive_kick", _attackDiveKick);
            _animator.SetFloat("Jab", _attackJab);
            _animator.SetFloat("Punch", _attackPunch);
            //_animator.SetFloat("JumpKick", _attackJumpKick);
            
            //Jump();

        }

        private void FixedUpdate()
        {
            _attackKick = 0f;
            _attackDiveKick = 0f;
            _attackJab = 0f;
            _attackPunch = 0f;
            _attackJumpKick = 0f;
        }

        private float Walk()
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
            {
                _walk = 1;
                return _walk;
            }
            else
            {
                _walk = 0;
                return _walk;
            }
        }

        private void Jump()
        {
            if (!_movementComponent.IsGrounded())
            {
                _animator.SetBool("Jump", true);
            }
            else
            {
                _animator.SetBool("Jump", false);
            }
        }
        
        private void Attack()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _attackKick = 1f;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _attackDiveKick = 1f;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                _attackJab = 1f;
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                _attackPunch = 1f;
            }
            if(Input.GetKeyDown(KeyCode.F) && !_movementComponent.IsGrounded())
            {
                _attackJumpKick = 1f;
            }
        }
    }
}


