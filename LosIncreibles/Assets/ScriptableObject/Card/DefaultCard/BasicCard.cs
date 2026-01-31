using UnityEngine;

[CreateAssetMenu(fileName = "BasicCard", menuName = "Cards/BasicCard")]
public class BasicCard : Card
{
    public float damage;
    public override void PlayCard()
    {
        CombatManager.Instance.GetPlayer().Attack(damage);
    }
}
