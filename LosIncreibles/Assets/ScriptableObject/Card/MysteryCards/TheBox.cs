using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "TheBox", menuName = "Cards/TheBox")]
public class TheBox : Card
{
    [SerializeField] private float damage = 10;
    private float percent = 0.5f;
    private bool youWin;


    public override void PlayCard()
    {
        while (Random.value <= percent)
        {
            Attack();
        }
    }

    public async void Attack()
    {
        CombatManager.Instance.GetPlayer().Attack(damage);
        await Task.Delay(500);
    }
}
