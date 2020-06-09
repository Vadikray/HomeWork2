using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerJump _playerJump;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerMovement.HorizontalDirection == 0)
            _animator.SetBool("isRunning", false);
        else
            _animator.SetBool("isRunning", true);

        if (_playerJump.IsGrounded)
            _animator.SetBool("isJumping", false);
        else
            _animator.SetBool("isJumping", true);
    }
}
