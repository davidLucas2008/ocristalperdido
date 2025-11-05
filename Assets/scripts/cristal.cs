using UnityEngine;
using UnityEngine.SceneManagement;

public class CrystalCollect : MonoBehaviour
{
    // Nome da próxima fase (você pode mudar no Inspector)
    public string proximaFase = "Fase2";

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que encostou é o jogador
        if (other.CompareTag("Player"))
        {
            // (Opcional) destrói o cristal
            Destroy(gameObject);

            // Carrega a próxima fase
            SceneManager.LoadScene(proximaFase);
        }
    }
}
