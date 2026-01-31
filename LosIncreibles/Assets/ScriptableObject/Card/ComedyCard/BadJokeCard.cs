using UnityEngine;

[CreateAssetMenu(fileName = "BadJokeCard", menuName = "Cards/BadJokeCard")]
public class BadJokeCard : Card
{
    public float normalDamage = 10f;
    public float potenciedDamage = 15f;
    public override void PlayCard()
    {
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Comedy)
        {
            foreach(Enemy enemy in EnemyManager.Instance.GetAllEnemies())
            {
                enemy.TakeDamage(potenciedDamage);
            }
        }
        else
        {

            CombatManager.Instance.currentEnemy.TakeDamage(normalDamage);
        }
    }
}
