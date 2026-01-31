using UnityEngine;

[CreateAssetMenu(fileName = "HitDoubleIfPoison", menuName = "Cards/HitDoubleIfPoison")]
public class HitDoubleIfPoison : Card
{
    public int damage = 10;
    public override void PlayCard()
    {
        Enemy enemy = CombatManager.Instance.GetCurrentEnemy();
        CombatManager.Instance.GetCurrentEnemy().TakeDamage(damage);
        if (enemy != null)
        {
            if (enemy.GetComponent<Poison>() != null)
            {
                CombatManager.Instance.GetCurrentEnemy().TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }
}
