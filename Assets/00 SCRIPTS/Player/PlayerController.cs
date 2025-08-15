using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("-----Move Player-----")]
    [SerializeField] protected float _speed;
    protected Vector2 _movement;
    protected Rigidbody2D _rb;
    protected bool _isOnGround;

    [Header("-----Check Double Jump-----")]
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected Transform _pointJump;
    [SerializeField] protected LayerMask _groundLayerMask;
    protected bool _canDoubleJump;

    [Header("-----Player Dash-----")]
    [SerializeField] protected float _forceDash;
    [SerializeField] protected float _timeDash;
    [SerializeField] protected float _dashCoolDown;
    protected bool _isDashing;
    protected bool _canDash = true;
    [SerializeField] protected float _dashTimeImage;

    [Header("-----Change Animation-----")]
    [SerializeField] protected PlayerState _playerState = PlayerState.Idle;
    [SerializeField] protected AnimationController _ani;

    [Header("-----ATTACKS-----")]
    [Header("---Atk1---")]
    [SerializeField] protected NormalAtk _normalAtk;
    [SerializeField] protected float _timeAtk1;
    protected bool _isAtk1 = false;

    [Header("---Atk2---")]
    [SerializeField] protected NormalAtk _normalAtk2;
    [SerializeField] protected float _timeAtk2;
    protected bool _isAtk2 = false;

    [Header("---Atk3---")]
    [SerializeField] protected NormalAtk _normalAtk3;
    [SerializeField] protected float _timeAtk3;
    protected bool _isAtk3 = false;

    [Header("Atk Speed Skill 1")]
    [SerializeField] protected float _atkSpeed;
    [SerializeField] protected float _countDownAtk;

    [Header("Atk Speed Skill 2)")]
    [SerializeField] protected float _atkSpeed2;
    [SerializeField] protected float _countDownAtk2;

    [Header("Atk Speed Skill 3")]
    [SerializeField] protected float _atkSpeed3;
    [SerializeField] protected float _countDownAtk3;

    [Header("UI skill")]
    [SerializeField] protected Image _imageSkill1;
    [SerializeField] protected Image _imageSkill2;
    [SerializeField] protected Image _imageSkill3;
    [SerializeField] protected Image _imageSkillDash;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _countDownAtk = _atkSpeed;
        _countDownAtk2 = _atkSpeed2;
        _countDownAtk3 = _atkSpeed3;
        _dashTimeImage = _dashCoolDown;
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
        this.Atks();
        this.UpdateSkill1();
        this.UpdateSkill2();
        this.UpdateSkill3();
        this.UpdateSkillDash();
        _countDownAtk += Time.deltaTime;
        _countDownAtk2 += Time.deltaTime;
        _countDownAtk3 += Time.deltaTime;
        _dashTimeImage += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_isDashing)
        {
            return;
        }
        _rb.velocity = new Vector2(_movement.x, _rb.velocity.y);
    }

    protected void Move()
    {
        _movement = _rb.velocity;
        if (_isAtk1 || _isAtk2 || _isAtk3)
        {
            _movement.x = 0;
        }
        else
        {
            _movement.x = Input.GetAxisRaw("Horizontal") * _speed;
        }
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
        AudioManager.Instance.PlaySFX(AudioManager.Instance._jumpSound);
    }

    protected void Dash()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canDash && _dashTimeImage >= _dashCoolDown)
        {
            _dashTimeImage = 0;
            StartCoroutine(PlayerDashing());
        }
    }

    protected void Atks()
    {
        if (Input.GetKeyDown(KeyCode.J) && !_isAtk1 && _countDownAtk >= _atkSpeed)
        {
            _countDownAtk = 0;
            StartCoroutine(Atk1AfterTime());
        }

        if (Input.GetKeyDown(KeyCode.K) && !_isAtk2 && _countDownAtk2 >= _atkSpeed2)
        {
            _countDownAtk2 = 0;
            StartCoroutine(Atk1AfterTime2());
        }

        if (Input.GetKeyDown(KeyCode.L) && !_isAtk3 && _countDownAtk3 >= _atkSpeed3)
        {
            _countDownAtk3 = 0;
            StartCoroutine(Atk1AfterTime3());
        }

    }

    protected IEnumerator Atk1AfterTime()
    {
        _isAtk1 = true;
        yield return new WaitForSeconds(_timeAtk1);
        _isAtk1 = false;
    }

    protected IEnumerator Atk1AfterTime2()
    {
        _isAtk2 = true;
        yield return new WaitForSeconds(_timeAtk2);
        _isAtk2 = false;
    }

    protected IEnumerator Atk1AfterTime3()
    {
        _isAtk3 = true;
        yield return new WaitForSeconds(_timeAtk3);
        _isAtk3 = false;
    }
    protected IEnumerator PlayerDashing()
    {
        _isDashing = true;
        float originGravityScale = _rb.gravityScale;
        _rb.gravityScale = 0f;
        AudioManager.Instance.PlaySFX(AudioManager.Instance._dashSound);
        _rb.velocity = new Vector2(transform.right.x * _forceDash, 0f);
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
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_rb.velocity.x < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
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
        if (_isAtk1)
        {
            _playerState = PlayerState.Atk1;
        }
        if (_isAtk2)
        {
            _playerState = PlayerState.Atk2;
        }
        if (_isAtk3)
        {
            _playerState = PlayerState.Atk3;
        }
    }

    protected void UpdateSkill1()
    {
        _imageSkill1.fillAmount = 1 - (_countDownAtk / _atkSpeed);
    }
    protected void UpdateSkill2()
    {
        _imageSkill2.fillAmount = 1 - (_countDownAtk2 / _atkSpeed2);
    }
    protected void UpdateSkill3()
    {
        _imageSkill3.fillAmount = 1 - (_countDownAtk3 / _atkSpeed3);
    }
    protected void UpdateSkillDash()
    {
        _imageSkillDash.fillAmount = 1 - (_dashTimeImage / _dashCoolDown);
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


