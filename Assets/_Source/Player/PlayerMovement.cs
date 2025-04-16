using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveVector;
    [SerializeField] public float moveSpeed = 4f;
    [SerializeField] public float jumpForce = 4f;
    private bool isGrounded;
    private bool isOnHold;
    [SerializeField] private float jumpWallHorizontal = 10f;
    [SerializeField] private Transform groundPos;
    [SerializeField] private Transform leftWallPos;
    [SerializeField] private Transform rightWallPos;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float dashPower;

    private bool canJump = true;
    private bool isJumping = false;
    private int jumpCount = 0;
    private bool isRightWall = false;
    private bool isLeftWall = false;
    private bool isOnWall = false;
    private bool canDash = true;
    private bool isDashing = false;
    private bool wallJumping = false;
    public float dir = 1;
    private bool canDoubleJump = false;
    private bool dashUnlocked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
    }

    private void FixedUpdate()
    {
        CheckGround();
        CheckWall();
        Walk();
        Jump();
        HandleWallCollision();
    }

    private void Walk()
    {
        if (wallJumping || isDashing) return;

        moveVector.x = Input.GetAxis("Horizontal");
        if (moveVector.x != 0) dir = moveVector.x;

        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
        attackPoint.localRotation = moveVector.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        anim.SetBool("Walk", moveVector.x != 0);
        if (Input.GetKey(KeyCode.F) && canDash && dashUnlocked)
        {
            StartCoroutine(DashReload());
        }
    }

    public void CheckAbilities()
    {
        canDoubleJump = PlayerPrefs.GetInt("canDoubleJump", 0) == 1;
        dashUnlocked = PlayerPrefs.GetInt("canDash", 0) == 1;

        Debug.Log($"DoubleJump: {canDoubleJump}, Dash: {dashUnlocked}");
    }

    private void Jump()
    {
        if ((isLeftWall || isRightWall) && Input.GetKey(KeyCode.Space) && canJump)
        {
            StartCoroutine(JumpWall());
            rb.velocity = Vector3.zero;
            float horizontalForce = isLeftWall ? jumpWallHorizontal : -jumpWallHorizontal;
            rb.AddForce(new Vector2(horizontalForce, jumpForce) * 10);
        }
        else if (Input.GetKey(KeyCode.Space) && (canDoubleJump == true && jumpCount > 0 || canDoubleJump == false && isGrounded == true) && canJump == true && wallJumping == false)
        {
            canJump = false;
            StartCoroutine(JumpReload());
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Vector2.up * jumpForce * 10);
            jumpCount -= 1;
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPos.position, 0.1f, groundLayer);
        isGrounded = colliders.Length > 0;
        anim.SetBool("Jump", !isGrounded);
        if (isGrounded && !isJumping)
        {
            jumpCount = canDoubleJump ? 2 : 1;
        }
    }

    private void CheckWall()
    {
        isLeftWall = Physics2D.OverlapCircle(leftWallPos.position, 0.02f, wallLayer);
        isRightWall = Physics2D.OverlapCircle(rightWallPos.position, 0.02f, wallLayer);
    }

    private void HandleWallCollision()
    {
        if (isRightWall && isLeftWall && !isJumping)
        {
            rb.gravityScale = 0.1f;
            if (!isOnWall)
            {
                rb.velocity = Vector3.zero;
                isOnWall = true;
            }
        }
        else if (!isRightWall && !isLeftWall && isJumping)
        {
            rb.gravityScale = 2;
            isOnWall = false;
        }
    }

    private IEnumerator JumpReload()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }

    private IEnumerator DashReload()
    {
        canDash = false;
        isDashing = true;
        rb.AddForce(new Vector2(dir * dashPower, rb.velocity.y), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        yield return new WaitForSeconds(0.8f);
        canDash = true;
    }

    private IEnumerator JumpWall()
    {
        wallJumping = true;
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
        yield return new WaitForSeconds(0.1f);
        canJump = true;
        yield return new WaitForSeconds(0.1f);
        wallJumping = false;
    }
}