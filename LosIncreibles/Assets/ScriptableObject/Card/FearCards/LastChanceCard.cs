using UnityEngine;

[CreateAssetMenu(fileName = "LastChanceCard", menuName = "Cards/LastChanceCard")]
public class LastChanceCard : Card
{
    public int damage = 30;
    public override void PlayCard()
    {
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Terror)
        {
            CombatManager.Instance.player.Attack(damage + 5);
        }else
        {
            CombatManager.Instance.player.Attack(damage);
        }
        CombatManager.Instance.player.TakeDamage(damage/2);
    }
}
