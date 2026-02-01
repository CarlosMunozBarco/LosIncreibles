using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "FocusTimeCard", menuName = "Cards/FocusTimeCard")]
public class FocusTimeCard : Card
{
    public int damage = 3;
    public override void PlayCard()
    {
        Attack();
    }
    public async void Attack()
    {
        for (int i = 0; i < 5; i++)
        {
            CombatManager.Instance.GetPlayer().Attack(damage);
            await Task.Delay(300);
        }
    }
}
