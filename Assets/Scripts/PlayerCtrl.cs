using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float jump, speed, groundPoin;
    [SerializeField] private Transform checkGround;
    [SerializeField] private GameObject H1, H2, H3, losePn, WinPn;
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput, Health = 3;

    private bool jumpInput, canJump, hasJump, isMoving, isKey, isRight = true;

    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        CheckInput();
        ApplyMove();
        CheckMove();
        CheckGround();
        UpdateAnimation();
    }

    private void CheckGround()
    {
        canJump = Physics2D.Raycast(checkGround.position, transform.up, groundPoin, groundLayer);
    }
    private void CheckMove()
    {
        if (isRight && moveInput <0)
        {
            Flip();
        }
        else if (!isRight && moveInput > 0)
        {
            Flip();
        }
    }
    private void UpdateAnimation()
    {
        anim.SetBool("isMove", isMoving);
    }
    private void Flip()
    {
        isRight = !isRight;
        transform.Rotate(0, 180, 0);
    }
    private void ApplyMove()
    {
        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
        SpriteRenderer spriteRenderer = rb.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;

    }
    private void CheckInput()
    {
        if (jumpInput && canJump && !hasJump)
        {
            Jump();
            hasJump = true;
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            KnockbackOpposite();
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            isKey = true;
        }
        if (collision.gameObject.CompareTag("Jump"))
        {
            jump = 30;
        }
        else
        {
            jump = 23;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && isKey)
        {
            if (SceneManager.GetActiveScene().buildIndex == 16)
            {
                WinPn.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1.0f;
            }
            
        }
        if (collision.gameObject.CompareTag("Apple"))
        {
            KnockbackOpposite();
        }
    }
    void KnockbackOpposite()
    {
        transform.Translate(new Vector2(-2, 0));
        Health--;
        if(Health == 2)
        {
            H3.SetActive(false);
        }
        else if(Health == 1)
        {
            H2.SetActive(false);
        }
        else if(Health == 0)
        {
            H1.SetActive(false);
            losePn.SetActive(true);
        }
    }

    public void ButtonRightDown(){moveInput = 1; isMoving = true; }
    public void ButtonRightUp(){moveInput = 0; isMoving = false; }
    public void ButtonLeftDown(){moveInput = -1; isMoving = true; }
    public void ButtonLeftUp(){moveInput = 0;isMoving = false; }
    public void ButtonJumpDown(){jumpInput = true;}
    public void ButtonJumpUp(){jumpInput = false;hasJump = false; }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(checkGround.position, new Vector3(checkGround.position.x, checkGround.position.y + groundPoin, checkGround.position.z));
    }
}
