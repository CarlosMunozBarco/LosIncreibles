using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "MultipleHitCard", menuName = "Cards/MultipleHitCard")]
public class MultipleHitCard : Card
{
    public int damage = 5;
    public override void PlayCard()
    {
        Attack();
    }
     public async void Attack()
    {
          List<Enemy> enemies = EnemyManager.Instance.GetAllEnemies();
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].TakeDamage(damage);  
        }

        CombatManager.Instance.player.Attack(0);
        await Task.Delay(500);

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].TakeDamage(damage);  
        }
        CombatManager.Instance.player.Attack(0);
    }
}
