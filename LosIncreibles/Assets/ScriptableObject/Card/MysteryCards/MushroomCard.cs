using UnityEngine;

[CreateAssetMenu(fileName = "MushroomCard", menuName = "Cards/MushroomCard")]
public class MushroomCard : Card
{
    public int heal = 15;
    public int damage = 10;
    public override void PlayCard()
    {
        float auxPercent = Random.value;
        if (auxPercent >= 0.5f)
        {
            CombatManager.Instance.player.Heal(heal);
        }else if (auxPercent <= 0.01f)
        {
            CombatManager.Instance.player.Heal(heal * 100);
        }else
        {
            CombatManager.Instance.player.TakeDamage(damage);
        }
    }
}
