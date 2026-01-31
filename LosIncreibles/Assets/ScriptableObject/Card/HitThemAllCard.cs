using UnityEngine;

[CreateAssetMenu(fileName = "HitThemAllCard", menuName = "Cards/HitThemAllCard")]
public class HitThemAllCard : Card
{
    public float damage = 5f;
    public override void PlayCard()
    {
        foreach(Enemy enemy in EnemyManager.Instance.GetAllEnemies())
        {
            enemy.TakeDamage(damage);
        }

    }
}
