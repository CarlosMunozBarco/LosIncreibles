using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalCard", menuName = "Cards/NormalCard")]
public class NormalCard : Card
{
    public float poisonDamage = 2f;
    public int initialStacks = 2;

    public override void PlayCard()
    {
        if(CombatManager.Instance.currentEnemy != null)
        {
            if(CombatManager.Instance.currentEnemy.GetComponent<Poison>() != null)
            {
                CombatManager.Instance.currentEnemy.GetComponent<Poison>().posionStacks = 
                    CombatManager.Instance.currentEnemy.GetComponent<Poison>().posionStacks + initialStacks;
            }
            else
            {
                CombatManager.Instance.currentEnemy.AddComponent<Poison>();
                CombatManager.Instance.currentEnemy.GetComponent<Poison>().damagePerTurn = poisonDamage;
                CombatManager.Instance.currentEnemy.GetComponent<Poison>().posionStacks = initialStacks;
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
        
    }
}
