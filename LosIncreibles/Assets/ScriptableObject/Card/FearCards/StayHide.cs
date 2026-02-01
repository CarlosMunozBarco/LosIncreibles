using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "StayHide", menuName = "Cards/StayHide")]
public class StayHide : Card
{
    public int damage = 5;
    public float dodgeChance = 0.05f;
    public override void PlayCard()
    {
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Terror)
        {
            CombatManager.Instance.player.Attack(damage + 5);
        }else
        {
            CombatManager.Instance.player.Attack(damage);
        }
        CombatManager.Instance.player.UpdateDodge(dodgeChance);
    }
}
