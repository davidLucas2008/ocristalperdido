using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [Header("Referência ao Player")]
    public PlayerCombat player; // arraste o player aqui no Inspector

    [Header("Imagens dos corações (em ordem)")]
    public Image[] hearts; // coloque 3 imagens de coração aqui

    [Header("Sprites dos estados")]
    public Sprite fullHeart;  // coração cheio
    public Sprite emptyHeart; // coração vazio

    void Update()
    {
        // Atualiza a exibição dos corações conforme a vida atual
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.maxHearts) // dentro do total possível
            {
                hearts[i].enabled = true; // mostra
                if (i < GetCurrentHearts())
                    hearts[i].sprite = fullHeart;
                else
                    hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].enabled = false; // esconde corações extras
            }
        }
    }

    int GetCurrentHearts()
    {
        // Pega a variável privada 'currentHearts' via reflexão (já que não queremos mudar o PlayerCombat)
        var field = typeof(PlayerCombat).GetField("currentHearts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (int)field.GetValue(player);
    }
}
