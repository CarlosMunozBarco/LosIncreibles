using UnityEngine;

[CreateAssetMenu(fileName = "LastChanceCard", menuName = "Cards/LastChanceCard")]
public class LastChanceCard : Card
{
    public int damage = 30;
    public override void PlayCard()
    {
        CombatManager.Instance.GetCurrentEnemy().TakeDamage(damage);
        CombatManager.Instance.player.TakeDamage(damage/2);
    }
}
