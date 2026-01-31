using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BandageCard", menuName = "Cards/BandageCard")]
public class BandangeCard : Card
{
    public int bandageStacks;
    public override void PlayCard()
    {
        if(CombatManager.Instance.player != null)
        {
            if(CombatManager.Instance.player.GetComponent<Bandages>() != null)
            {
                CombatManager.Instance.player.GetComponent<Bandages>().bandagesStack += bandageStacks;
            }
            else
            {
                CombatManager.Instance.player.AddComponent<Bandages>();
                CombatManager.Instance.player.GetComponent<Bandages>().bandagesStack = bandageStacks;
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }
}
