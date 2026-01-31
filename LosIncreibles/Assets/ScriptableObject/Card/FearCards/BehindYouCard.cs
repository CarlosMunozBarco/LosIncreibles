using UnityEngine;

[CreateAssetMenu(fileName = "BehindYouCard", menuName = "Cards/BehindYouCard")]
public class BehindYouCard : Card
{
    public int damage = 10;
    public int shield = 20;
    public override void PlayCard()
    {
        CombatManager.Instance.player.TakeDamage(damage);
        CombatManager.Instance.player.shield += shield;
    }
}
