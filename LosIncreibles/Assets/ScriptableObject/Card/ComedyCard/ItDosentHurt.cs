using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItDosentHurt", menuName = "Cards/ItDosentHurt")]
public class ItDosentHurt : Card
{
    public int shield;
    public int poisonStack;


    public override void PlayCard()
    {
        CombatManager.Instance.player.shield += shield;
        
        if(CombatManager.Instance.player != null)
        {
            if(CombatManager.Instance.currentEnemy.GetComponent<Poison>() != null)
            {
                CombatManager.Instance.player.GetComponent<Poison>().poisonStacks += poisonStack; 
                
            }
            else
            {
                CombatManager.Instance.player.AddComponent<Poison>();
                CombatManager.Instance.player.GetComponent<Poison>().damagePerTurn = poisonStack;
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }
}
