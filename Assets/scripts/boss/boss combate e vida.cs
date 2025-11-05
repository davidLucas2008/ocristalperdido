using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;
    public float damageToPlayer = 1f; // Dano que o boss causa ao player
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica se o player está pulando em cima do boss
            if (collision.contacts[0].normal.y < -0.5f)
            {
                TakeDamage(1);
            }

            // Causa dano ao player sempre que encostar
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
            if (playerCombat != null)
            {
                playerCombat.TakeDamage((int)damageToPlayer);
            }
        }
    }

    void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log("Boss recebeu dano! Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Boss morreu!");
        Destroy(gameObject); // Remove completamente o boss da cena
    }
}
