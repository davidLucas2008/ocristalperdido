using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    [Header("Movimento Vertical")]
    public float distancia = 3f;  // altura que a plataforma vai se mover
    public float velocidade = 2f; // velocidade do movimento

    private Vector3 posicaoInicial;
    private float direcao = 1f;

    private Transform jogadorEmCima = null; // referência ao jogador quando está em cima

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        // Move a plataforma para cima e para baixo
        Vector3 movimento = Vector3.up * direcao * velocidade * Time.deltaTime;
        transform.position += movimento;

        // Move o jogador junto com a plataforma
        if (jogadorEmCima != null)
        {
            jogadorEmCima.position += movimento;
        }

        // Inverte direção ao atingir limites
        if (transform.position.y > posicaoInicial.y + distancia)
            direcao = -1f;
        else if (transform.position.y < posicaoInicial.y - distancia)
            direcao = 1f;
    }

    // Detecta quando algo colide com a plataforma
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Se for o jogador, ele está em cima da plataforma
        if (col.gameObject.CompareTag("Player"))
        {
            // Checa se o contato está vindo de cima
            foreach (ContactPoint2D ponto in col.contacts)
            {
                if (ponto.normal.y > 0.5f) // colisão pelo topo
                {
                    jogadorEmCima = col.transform;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        // Quando o jogador sai da plataforma
        if (col.gameObject.CompareTag("Player"))
        {
            jogadorEmCima = null;
        }
    }
}

