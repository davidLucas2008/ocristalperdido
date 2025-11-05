using UnityEngine;

public class Slime : MonoBehaviour
{
    [Header("Configurações de movimento")]
    public float speed = 3f; // Velocidade do inimigo
    public float detectionRange = 2f; // Distância em que o Slime começa a perseguir o jogador

    private Transform player;

    void Start()
    {
        // Encontra o jogador pela tag "Player"
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player não encontrado. Certifique-se de que o Player tem a tag 'Player'.");
            enabled = false;
        }
    }

    void Update()
    {
        if (player == null) return;

        // Calcula a distância até o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Só se move se o jogador estiver dentro do alcance
        if (distanceToPlayer <= detectionRange)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    // Opcional: visualizar o raio de detecção no editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}




