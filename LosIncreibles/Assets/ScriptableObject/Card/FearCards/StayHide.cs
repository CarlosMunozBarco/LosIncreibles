using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "StayHide", menuName = "Cards/StayHide")]
public class StayHide : Card
{
    public int damage = 5;
    public float dodgeChance = 0.05f;
    public override void PlayCard()
    {
        CombatManager.Instance.GetCurrentEnemy().TakeDamage(damage);
        CombatManager.Instance.player.UpdateDodge(dodgeChance);
    }
}
