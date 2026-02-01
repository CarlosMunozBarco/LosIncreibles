using UnityEngine;

[CreateAssetMenu(fileName = "UnderTheBlankets", menuName = "Cards/UnderTheBlankets")]
public class UnderTheBlankets : Card
{
    public int shield;
    public int damage;
    public override void PlayCard()
    {
        CombatManager.Instance.GetPlayer().Attack(damage);
        CombatManager.Instance.player.UpdateShield(shield);
    }
}
    

