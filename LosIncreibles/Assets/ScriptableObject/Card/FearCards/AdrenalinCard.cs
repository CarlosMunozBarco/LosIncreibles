using UnityEngine;

[CreateAssetMenu(fileName = "AdrenalinCard", menuName = "Cards/AdrenalinCard")]
public class AdrenalinCard : Card
{
    public int damage = 20;
    public override void PlayCard()
    {
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Terror)
        {
            CombatManager.Instance.player.Attack(damage + 5);
        }else
        {
            CombatManager.Instance.player.Attack(damage);
        }
    }
}
