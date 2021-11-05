using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour, IDamageble
{
    private Rigidbody2D _rigid;
    private PlayerAnimation _playerAnima;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordSprite;
    private Diamond Diamond;
    private Animator _animator;


    [SerializeField]
    private float _jumpForce = 5f;       // Force to apply when lifting the rigidbody.
    [SerializeField]
    private bool _isGrounded = false;
    private bool _jumpFix = false;
    [SerializeField]
    private float _speedPlayer = 2f;
    public int diamound;
    protected bool isDeath = false;
    protected bool playerIsLive = true;
    public int Health { get; set; }
    public void Init()
    {

    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        Diamond = GameObject.FindGameObjectWithTag("Diamond").GetComponent<Diamond>();
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnima = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    void Update()
    {
        Movement();
        CheckJamping();
        UIManager.Instance.UpdateGemCount(diamound);

        if (Input.GetMouseButtonDown(0) /*|| CrossPlatformInputManager.GetButtonDown("A_Button")*/ && _isGrounded == true)
        {
            _playerAnima.Attacking();
        }
    }
    void Movement()
    {
        if (playerIsLive == true)
        {
            float move = /*CrossPlatformInputManager.GetAxis("Horizontal")*/ Input.GetAxisRaw("Horizontal");

            Fliping(move);

            // Jumping
            if ((Input.GetKey(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && _isGrounded == true)
            {
                _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
                _isGrounded = false;
                _jumpFix = true;
                _playerAnima.Jump(true);
                StartCoroutine(JumpFixRutine());
            }
            else
            {
                _rigid.velocity = new Vector2(move * _speedPlayer, _rigid.velocity.y);
                _playerAnima.Move(move);
            }
        }
    }

    void CheckJamping()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        // If it hits something...
       // Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);
        if (hitInfo.collider != null)
        {
            //  _playerAnima.StartRuning();
            if (_jumpFix == false)
            {
                _isGrounded = true;
                _playerAnima.Jump(false);
            }
        }
    }

    void Fliping(float moves)
    {
        // Fliping a Player
        if (move < 0)
        {
            _playerSprite.flipX = true;
            _swordSprite.flipX = true;
            _swordSprite.flipY = true;

            Vector3 newpos = _swordSprite.transform.localPosition;
            newpos.x = -1.01f;
            _swordSprite.transform.localPosition = newpos;
        }
        else if (move > 0)
        {
            _playerSprite.flipX = false;
            _swordSprite.flipX = false;
            _swordSprite.flipY = false;

            Vector3 newpos = _swordSprite.transform.localPosition;
            newpos.x = 1.01f;
            _swordSprite.transform.localPosition = newpos;
        }
    }

    IEnumerator JumpFixRutine()
    {
        yield return new WaitForSeconds(0.1f);
        _jumpFix = false;
    }
    public void Damage()
    {
        if (isDeath)
        {
            return;
        }
        Health--;
        
        UIManager.Instance.UpdateLives(Health);
        
        if (Health < 1)
        {
            isDeath = true;
            
            _playerAnima.Dead();
            playerIsLive = false;
           
        }
    }
    public void AddGems(int amout)
    {
        diamound += amout;
    }
}