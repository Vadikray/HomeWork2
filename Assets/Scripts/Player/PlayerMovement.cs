using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    public float HorizontalDirection { get; private set; }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalDirection = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(HorizontalDirection * _speed, _rigidbody2D.velocity.y);
        Flip();
    }

    private void Flip()
    {
        if (HorizontalDirection > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (HorizontalDirection < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
