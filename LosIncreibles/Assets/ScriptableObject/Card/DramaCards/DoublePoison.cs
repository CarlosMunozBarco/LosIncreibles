using UnityEngine;

[CreateAssetMenu(fileName = "DoublePoison", menuName = "Cards/DoublePoison")]
public class DoublePoison : Card
{
    public override void PlayCard()
    {
       Enemy enemy = CombatManager.Instance.GetCurrentEnemy();
        if (enemy != null)
        {
            if (enemy.GetComponent<Poison>() != null)
            {
                enemy.GetComponent<Poison>().poisonStacks = enemy.GetComponent<Poison>().poisonStacks * 2;
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }
}
