using UnityEngine;

[CreateAssetMenu(fileName = "ShieldCard", menuName = "Cards/ShieldCard")]
public class ShieldCard : Card
{
    public float shield = 10;
    public override void PlayCard()
    {
        CombatManager.Instance.player.shield += shield;
    }
}
