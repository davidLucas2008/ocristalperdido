using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;
    public float activationDistance = 10f;

    private Transform player;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            Debug.LogError("Player não encontrado. Certifique-se de que o Player tem a tag 'Player'.");
            enabled = false;
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Ativa o boss quando o player se aproxima
            if (distanceToPlayer < activationDistance && !isActivated)
            {
                isActivated = true;
                Debug.Log("Boss ativado!");
            }

            if (isActivated)
            {
                // Segue o player
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * speed * Time.deltaTime);

                // Vira o sprite baseado na direção
                if (direction.x > 0)
                {
                    spriteRenderer.flipX = false; // Direita
                }
                else if (direction.x < 0)
                {
                    spriteRenderer.flipX = true; // Esquerda
                }
            }
        }
    }
}