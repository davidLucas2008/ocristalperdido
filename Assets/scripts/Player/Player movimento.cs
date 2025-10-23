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
    public float airTime = 4f; // tempo que o player fica no ar
    private bool isJumping = false;

    [Header("Componentes")]
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Movimento lateral
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1;
            anim.SetBool("IsRight", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1;
            anim.SetBool("IsRight", false);
        }
        else
        {
            moveInput = 0;
            anim.SetBool("IsRight", false);
        }

        // Aplica movimento
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Flip visual
        sr.flipX = moveInput < 0;

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(JumpRoutine());
        }

        // Reset animações de pulo se encostar no chão
        if (isGrounded && !isJumping)
        {
            anim.SetBool("IsJumpRight", false);
            anim.SetBool("IsJumpLeft", false);
        }
    }

    private IEnumerator JumpRoutine()
    {
        isJumping = true;

        // Pulo direcional
        float jumpX = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            jumpX = speed;
            anim.SetBool("IsJumpRight", true);
            anim.SetBool("IsJumpLeft", false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            jumpX = -speed;
            anim.SetBool("IsJumpLeft", true);
            anim.SetBool("IsJumpRight", false);
        }

        rb.velocity = new Vector2(jumpX, jumpForce);

        // Mantém no ar por "airTime" segundos
        yield return new WaitForSeconds(airTime);

        // Cai de volta
        rb.velocity = new Vector2(rb.velocity.x, -jumpForce);

        isJumping = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

