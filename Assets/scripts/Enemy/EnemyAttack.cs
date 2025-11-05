using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Vida do Inimigo")]
    public int maxHeartsEnemy = 1;
    public int damageToPlayer = 1;

    void Start()
    {
        Debug.Log($"❤️ Enemy começou com {maxHeartsEnemy}");
    }

    void Update()
    {
        // (Pode deixar vazio ou adicionar lógica extra depois)
    }

    public void TakeDamageEnemy(int damage)
    {
        maxHeartsEnemy -= damage;

        if (maxHeartsEnemy <= 0)
            DieEnemy();
    }

    void DieEnemy()
    {
        Debug.Log($"💀 Enemy morreu");
        Destroy(gameObject); // Faz o inimigo sumir do cenário
    }
}

