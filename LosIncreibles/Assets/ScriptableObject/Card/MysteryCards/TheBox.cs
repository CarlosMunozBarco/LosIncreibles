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
        if(MaskManager.Instance.currentMask.maskInfo.maskType == MaskType.Drama)
        {
            CombatManager.Instance.player.Attack(damage + 5);
        }else
        {
            CombatManager.Instance.player.Attack(damage);
        }
        await Task.Delay(500);
    }
}
