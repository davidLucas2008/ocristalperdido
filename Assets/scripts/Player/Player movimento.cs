using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimentação")]
    public float speed = 5f;
    private float moveInput;

    [Header("Pulo")]
    public float jumpForce = 7f;
    public float airTime = 0.4f;
    private bool isJumping = false;

    [Header("Componentes")]
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    [Header("Debug")]
    public bool debugLogs = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //movimentação
        moveInput = Input.GetAxisRaw("Horizontal");

        // Checa se está no chão 
        if (groundCheck != null)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        else
            isGrounded = false;
        // Flip
        if (sr != null)
        {
            if (moveInput > 0) sr.flipX = false;
            else if (moveInput < 0) sr.flipX = true;
        }

        //animação
        if (animator != null)
            animator.SetBool("IsRunning", moveInput != 0);
        // Pulo 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
        // Atualiza animação
        if (animator != null)
            animator.SetBool("IsJumpRight", !isGrounded);
        if (debugLogs)
        {
            Debug.Log($"moveInput: {moveInput}, isGrounded: {isGrounded}, isJumping: {isJumping}");
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    private IEnumerator JumpRoutine()
    {
        isJumping = true;

        if (animator != null)
            animator.SetBool("IsJumpRight", true);

        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        yield return new WaitForSeconds(airTime);

        isJumping = false;

        if (animator != null)
            animator.SetBool("IsJumpRight", false);
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
