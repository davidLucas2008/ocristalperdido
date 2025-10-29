using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se quem tocou é o player
        if (other.CompareTag("Player"))
        {
            // Aqui você poderia adicionar efeitos ou sons

            // Destrói a moeda
            Destroy(gameObject);
        }
    }
}