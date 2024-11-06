using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Vector2 moveVector;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpForce = 4f;
    private bool isGrounded;
    private bool isOnHold;
    [SerializeField] float jumpWallHorizontal = 10;
    [SerializeField] Transform groundPos;
    [SerializeField] Transform leftWallPos;
    [SerializeField] Transform rightWallPos;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;
    private bool canJump = true;
    private bool isJumping = false;
    private int jumpCount = 0;
    public bool isRightWall = false;
    public bool isLeftWall = false;
    bool isOnWall = false;
    bool wallJumpimg = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckGround();
        CheckLeft();
        CheckRight();
        Walk();
        Jump();
        if (isRightWall == true || isLeftWall == true && isJumping == false)
        {
            rb.gravityScale = 0.1f;
            if(isOnWall == false)
            {
                rb.velocity = new Vector3(0, 0, 0);
                isOnWall = true;
            }
        }
        if ((isRightWall == false && isLeftWall == false) || isJumping == true)
        {
            rb.gravityScale = 2;
            isOnWall = false;
        }
        
    }
    void Walk()
    {
        if (wallJumpimg == true) return;
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
      

    }
    void Jump()
    {
        if(isLeftWall == true && Input.GetKey(KeyCode.Space) && canJump == true)
        {
            StartCoroutine(JumpWall());
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(jumpWallHorizontal, jumpForce) * 10);


        }
        else if (isRightWall == true && Input.GetKey(KeyCode.Space) && canJump == true)
        {
            StartCoroutine(JumpWall());
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(jumpWallHorizontal * -1, jumpForce) * 10);
            
        }
        else if (Input.GetKey(KeyCode.Space) && jumpCount > 0 && canJump == true && wallJumpimg == false)
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
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundPos.position, 0.1f, groundLayer);
        isGrounded = collider.Length > 0;
        if  (isGrounded == true && isJumping == false) jumpCount = 2;
    }
    private void CheckLeft()
    {
        
        Collider2D[] collider = Physics2D.OverlapCircleAll(leftWallPos.position, 0.02f, wallLayer);
        isLeftWall = collider.Length > 0;
        
    }
    private void CheckRight()
    {
        
        Collider2D[] collider = Physics2D.OverlapCircleAll(rightWallPos.position, 0.02f, wallLayer);
        isRightWall = collider.Length > 0;
    }
    IEnumerator JumpReload()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }
    IEnumerator JumpWall()
    {
        wallJumpimg = true;
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
        yield return new WaitForSeconds(0.1f);
        canJump = true;
        yield return new WaitForSeconds(0.1f);
        wallJumpimg = false;
    }
}