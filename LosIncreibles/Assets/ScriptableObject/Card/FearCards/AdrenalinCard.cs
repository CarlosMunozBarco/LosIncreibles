using UnityEngine;

[CreateAssetMenu(fileName = "AdrenalinCard", menuName = "Cards/AdrenalinCard")]
public class AdrenalinCard : Card
{
    public int damage = 20;
    public override void PlayCard()
    {
        CombatManager.Instance.GetCurrentEnemy().TakeDamage(damage);
    }
}
