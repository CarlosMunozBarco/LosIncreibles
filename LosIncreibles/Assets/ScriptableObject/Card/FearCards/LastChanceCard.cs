using UnityEngine;

[CreateAssetMenu(fileName = "LastChanceCard", menuName = "Cards/LastChanceCard")]
public class LastChanceCard : Card
{
    public int damage = 30;
    public override void PlayCard()
    {
        CombatManager.Instance.GetPlayer().Attack(damage);
        CombatManager.Instance.player.TakeDamage(damage/2);
    }
}
