using UnityEngine;

[CreateAssetMenu(fileName = "ItDosentHurt", menuName = "Cards/ItDosentHurt")]
public class ItDosentHurt : Card
{
    public int shield;
    public int poisonStack;


    public override void PlayCard()
    {
        CombatManager.Instance.player.shield += shield;
        
    }
}
