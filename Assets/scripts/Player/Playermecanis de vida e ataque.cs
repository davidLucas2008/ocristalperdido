using UnityEngine;
using UnityEngine.SceneManagement; // <- necessário para trocar de cena

public class PlayerCombat : MonoBehaviour
{
    [Header("Vida do Jogador (Corações)")]
    public int maxHearts = 3;
    private int currentHearts;

    [Header("Pulo sobre inimigo")]
    public float bounceForce = 7f; // força do pulo após acertar inimigo

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHearts = maxHearts;
        Debug.Log($"❤️ Player começou com {currentHearts} corações.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta colisão com inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAttack enemy = collision.gameObject.GetComponent<EnemyAttack>();
            if (enemy == null) return;

            // Pega o ponto de contato mais próximo
            ContactPoint2D contato = collision.contacts[0];

            // Verifica se o player atingiu o inimigo por cima
            bool hitFromAbove = contato.normal.y > 0.5f;

            if (hitFromAbove)
            {
                // Player acerta o inimigo e rebate pra cima
                enemy.TakeDamageEnemy(1);
                rb.velocity = new Vector2(rb.velocity.x, bounceForce);
                Debug.Log("🦘 Player pulou sobre o inimigo!");
            }
            else
            {
                // Player leva dano ao tocar de lado ou por baixo
                TakeDamage(enemy.damageToPlayer);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        if (currentHearts < 0) currentHearts = 0;

        Debug.Log($"💔 Player levou {damage} de dano! Corações restantes: {currentHearts}");

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("☠️ Player morreu!");
        SceneManager.LoadScene("game over"); // <- Nome da cena de Game Over
    }
}


