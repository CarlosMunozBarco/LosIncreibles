using UnityEngine;

[CreateAssetMenu(fileName = "UnderTheBlankets", menuName = "Cards/UnderTheBlankets")]
public class UnderTheBlankets : Card
{
    public int shield;
    public int damage;
    public override void PlayCard()
    {
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Terror)
        {
            CombatManager.Instance.player.Attack(damage + 5);
        }else
        {
            CombatManager.Instance.player.Attack(damage);
        }
        CombatManager.Instance.player.UpdateShield(shield);
    }
}
    

