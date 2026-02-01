using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "HitDoubleIfPoison", menuName = "Cards/HitDoubleIfPoison")]
public class HitDoubleIfPoison : Card
{
    public int damage = 10;
    public override void PlayCard()
    {
        Enemy enemy = CombatManager.Instance.GetCurrentEnemy();
        Attack();
        if (enemy != null)
        { 
            if (enemy.GetComponent<Poison>() != null)
            {
                Attack();
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }

    private async void Attack()
    {
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Drama)
        {
            CombatManager.Instance.GetPlayer().Attack(damage + 5);        
        }else
        {
            CombatManager.Instance.GetPlayer().Attack(damage); 
        }

        await Task.Delay(500);
    }
}
