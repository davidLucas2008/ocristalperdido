using UnityEngine;
using UnityEngine.SceneManagement; // Para trocar de cena

public class MenuController : MonoBehaviour
{
    void Update()
    {
        // Quando o jogador apertar Enter (Return)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Carrega a cena "Fase1"
            SceneManager.LoadScene("Fase_1");
        }
    }
}
