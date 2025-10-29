using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se quem tocou � o player
        if (other.CompareTag("Player"))
        {
            // Aqui voc� poderia adicionar efeitos ou sons

            // Destr�i a moeda
            Destroy(gameObject);
        }
    }
}