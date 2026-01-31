using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalCard", menuName = "Cards/NormalCard")]
public class NormalCard : Card
{
    public float poisonDamage = 2f;
    public int initialStacks = 2;

    public override void PlayCard()
    {
        Enemy enemy = CombatManager.Instance.GetCurrentEnemy();
        if (enemy != null)
        {
            if (enemy.GetComponent<Poison>() != null)
            {
                enemy.GetComponent<Poison>().poisonStacks =
                    enemy.GetComponent<Poison>().poisonStacks + initialStacks;
            }
            else
            {
                enemy.AddComponent<Poison>();
                enemy.GetComponent<Poison>().damagePerTurn = poisonDamage;
                enemy.GetComponent<Poison>().poisonStacks = initialStacks;
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
        
    }
}
