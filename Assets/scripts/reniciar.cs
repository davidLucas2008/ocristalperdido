using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    public void JogadorMorreu()
    {
        // Salva o nome da cena atual (fase onde o jogador morreu)
        string cenaAtual = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("UltimaFase", cenaAtual);

        // Carrega a tela de Game Over
        SceneManager.LoadScene("GameOver");
    }
}
