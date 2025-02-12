using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    protected Vector2 _movement;
    protected Rigidbody2D _rb;
    protected bool _isOnGround;
    [SerializeField] protected Transform _pointJump;
    [SerializeField] protected LayerMask _groundLayerMask;
    protected bool _canDoubleJump;
    [SerializeField] protected float _forceDash;
    [SerializeField] protected float _timeDash;
    [SerializeField] protected float _dashCoolDown;
    protected bool _isDashing;
    protected bool _canDash = true;
    [SerializeField] protected PlayerState _playerState = PlayerState.Idle;
    [SerializeField] protected AnimationController _ani;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (_isDashing)
        {
            return;
        }
        this.Move();
        this.DoubleJump();
        this.Turning();
        this.Dash();
        this.ChangeAni();
        _ani.UpdateAnimation(_playerState);
    }

    private void FixedUpdate()
    {
        if (_isDashing)
        {
            return;
        }
        _rb.velocity = _movement;
    }

    protected void Move()
    {
        _movement = _rb.velocity;
        _movement.x = Input.GetAxisRaw("Horizontal") * _speed;
    }

    protected void DoubleJump()
    {
        _isOnGround = Physics2D.OverlapCircle(_pointJump.transform.position, 0.2f, _groundLayerMask);

        if (_isOnGround)
        {
            _canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isOnGround)
            {
                this.Jump();
            }
            else if (_canDoubleJump)
            {
                this.Jump();
                _canDoubleJump = false;
            }
        }

    }

    protected void Jump()
    {
        _rb.AddForce(new Vector2(0, _jumpForce));
    }

    protected void Dash()
    {
        if (Input.GetKeyDown(KeyCode.C) && _canDash)
        {
            StartCoroutine(PlayerDashing());
        }
    }

    protected IEnumerator PlayerDashing()
    {
        _isDashing = true;
        float originGravityScale = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * _forceDash, 0f);
        _canDash = false;
        yield return new WaitForSeconds(_timeDash);
        _rb.gravityScale = originGravityScale;
        _isDashing = false;
        yield return new WaitForSeconds(_dashCoolDown);
        _canDash = true;
    }

    protected void Turning()
    {
        if (_rb.velocity.x > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_rb.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    protected void ChangeAni()
    {
        if (!_isOnGround)
        {
            _playerState = PlayerState.Jump;
        }
        else
        {
            if (_movement.x != 0)
            {
                _playerState = PlayerState.Run;
            }
            else
            {
                _playerState = PlayerState.Idle;
            }
        }
        if (_isDashing)
        {
            _playerState = PlayerState.Walk;
        }
    }
    public enum PlayerState
    {
        Idle,
        Jump,
        Walk,
        Atk1,
        Atk2,
        Atk3,
        Hurt,
        Die,
        Run,
    }
}


