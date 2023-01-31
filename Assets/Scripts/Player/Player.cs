using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Field Declaration

    public Transform raycastPos;
    [SerializeField] private Canvas gameUI;
    [SerializeField] private Text score;
    [SerializeField] private int coinsCollected;
    private Rigidbody2D _playerRb;
    private Vector2 _jumpDirection = new Vector2(0f, 5f);
    [SerializeField]private float jumpForce;
    public bool isGrounded;
    public bool isLanded;
    [SerializeField] private bool jump;
    private Animator _playerAnimator;
    private float _yLastPos;
    public bool isGameOver { get; private set; }
    private const int _powerMultiplyer = 2;

    #endregion

    #region Unity Methods

    void Awake()
    {
        isGameOver = false;
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponentInChildren<Animator>();
        _yLastPos = transform.position.y;
    }

    private void Start()
    {
        _playerAnimator.SetBool("isFalling", true);
    }

    void Update()
    {
        CharacterJump();
        CharcterLanding();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeadBox"))
        {
            isGameOver = true;
            gameUI.gameObject.SetActive(true);
            score.text = "Score: " + coinsCollected;
        }
        if (other.CompareTag("Collectable"))
        {
            coinsCollected++;
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Power"))
            coinsCollected *=_powerMultiplyer;
        Destroy(other.gameObject);
    }

    private void FixedUpdate()
    {
        CheckIfGrounded();
        CharacterJumpPhysics();
    }

    #endregion
    
    #region Ground Check

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastPos.position, Vector2.down);

        if (hit.collider)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
                _playerAnimator.SetBool("isRunning", true);
                //Debug.DrawRay(raycastPos.position, Vector2.down, Color.green);
            }
            else
            {
                isGrounded = false;
                _playerAnimator.SetBool("isRunning", false);
            }
        }
       
    }

    #endregion
    
    #region Jump Logic

    void CharacterJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/CharacterSounds/Character_Jump", transform.position);
            _playerAnimator.SetTrigger("Jump");
            jump = true;
            isGrounded = false;
        }
    }

    void CharcterLanding()
    {
        if (transform.position.y < _yLastPos)
        {
            _playerAnimator.SetBool("isFalling", true);
            isLanded = false;
        }
            
        else
        {
            _playerAnimator.SetBool("isFalling", false);
            isLanded = true;
            
        }
           

        _yLastPos = transform.position.y;
    }

    void CharacterJumpPhysics()
    {
        if (jump)
        {
            jump = false;
            _playerRb.AddForce(_jumpDirection * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    #endregion
   
}
