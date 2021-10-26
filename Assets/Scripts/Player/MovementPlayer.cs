using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _platformLayerMask;

    private float _movement;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Run();
        Jump();
        Flip();
        RunAnimation();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_movement * _speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void RunAnimation()
    {
        _animator.SetBool(AnimatorPlayerController.Params.isGround, !CheckGround());
        _animator.SetFloat(AnimatorPlayerController.Params.VelocityY, _rigidbody2D.velocity.y);
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, Mathf.Abs(_movement));
    }

    private void Run()
    {
        _movement = Input.GetAxis("Horizontal");
    }

    private bool CheckGround()
    {
        return Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, .1f, _platformLayerMask);
    }

    private void Flip()
    {
        _spriteRenderer.flipX = _movement < 0.0;
    }
}
