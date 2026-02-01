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
        Player player = CombatManager.Instance.GetPlayer();
        Enemy enemy = CombatManager.Instance.GetCurrentEnemy();

        if (enemy.GetComponent<Laugh>() != null)
        {
            player.Attack(2 * damage);
        }
        else
        {
            player.Attack(damage);
        }

        await Task.Delay(500);  

        enemy = CombatManager.Instance.GetCurrentEnemy();

        if (enemy.GetComponent<Laugh>() != null)
        {
            player.Attack(2 * damage);
        }
        else
        {
            player.Attack(damage);
        }
    }
}
    

