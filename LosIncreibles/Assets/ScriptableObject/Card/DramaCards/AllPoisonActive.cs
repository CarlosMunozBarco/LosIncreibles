using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "AllPoisonActive", menuName = "Cards/AllPoisonActive")]
public class AllPoisonActive : Card
{
    public int damage;
    public override void PlayCard()
    {
        Attack();
    }
    public void Attack()
    {
        List<Enemy> enemies = EnemyManager.Instance.GetAllEnemies();
        for (int i = 0; i < enemies.Count; i++)
        {
            PoisonEnemy(enemies[i]);
            enemies[i].TakeDamage(enemies[i].GetComponent<Poison>().poisonStacks);  
        }
    }    

    public void PoisonEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            if (enemy.GetComponent<Poison>() != null)
            {
                enemy.GetComponent<Poison>().poisonStacks = enemy.GetComponent<Poison>().poisonStacks + 1;
            }
            else
            {
                enemy.AddComponent<Poison>().poisonStacks = 1;
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }

    
}
