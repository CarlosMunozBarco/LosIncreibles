using UnityEngine;

[CreateAssetMenu(fileName = "BrokeSwordCard", menuName = "Cards/BrokeSwordCard")]
public class BrokeSwordCard : Card
{
    public int damage;
    public override void PlayCard()
    {
        damage = Random.Range(5, 26);
        CombatManager.Instance.GetPlayer().Attack(damage);
    }
}
    

