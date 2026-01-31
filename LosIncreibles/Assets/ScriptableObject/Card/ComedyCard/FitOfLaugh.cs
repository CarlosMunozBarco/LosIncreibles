using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "FitOfLaugh", menuName = "Cards/FitOfLaugh")]
public class FitOfLaugh : Card
{
    public float damage = 10;
    public override void PlayCard()
    {
        DealDamage();
    }

    public async void DealDamage()
    {
        Enemy enemy = CombatManager.Instance.currentEnemy;

        if(enemy.GetComponent<Laugh>() != null)
        {
            enemy.TakeDamage(2 * damage);
        }
        else
        {
            enemy.TakeDamage(damage);
        }

        await Task.Delay(500);  

        enemy = CombatManager.Instance.currentEnemy;

        if(enemy.GetComponent<Laugh>() != null)
        {
            enemy.TakeDamage(2 * damage);
        }
        else
        {
            enemy.TakeDamage(damage);
        }
    }
}
    

