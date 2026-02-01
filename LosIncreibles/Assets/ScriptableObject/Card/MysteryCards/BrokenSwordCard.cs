using UnityEngine;

[CreateAssetMenu(fileName = "BrokeSwordCard", menuName = "Cards/BrokeSwordCard")]
public class BrokeSwordCard : Card
{
    public int damage;
    public override void PlayCard()
    {
        damage = Random.Range(5, 26);
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Drama)
        {
            CombatManager.Instance.player.Attack(damage + 5);
        }else
        {
            CombatManager.Instance.player.Attack(damage);
        }
        
    }
}
    

