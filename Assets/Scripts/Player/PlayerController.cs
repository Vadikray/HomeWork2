using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalDirection;
    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(_horizontalDirection * _speed, _rigidbody2D.velocity.y);
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.4f, _whatIsGround);

        if (_horizontalDirection == 0)
            _animator.SetBool("isRunning", false);
        else
            _animator.SetBool("isRunning", true);

        if (_isGrounded)
            _animator.SetBool("isJumping", false);
        else
            _animator.SetBool("isJumping", true);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        Flip();
    }
    private void Flip()
    {
        if (_horizontalDirection > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (_horizontalDirection < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
