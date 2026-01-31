using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "LaughingToKeepFromCryingCard", menuName = "Scriptable Objects/LaughingToKeepFromCryingCard")]
public class LaughingToKeepFromCryingCard : Card
{
    public int bandagesAmount = 3;
    public override void PlayCard()
    {
        if(CombatManager.Instance.player.GetComponent<Bandages>() == null)
        {
            CombatManager.Instance.player.AddComponent<Bandages>().bandagesStack = bandagesAmount;
        }
        else
        {
            Bandages bandages = CombatManager.Instance.player.GetComponent<Bandages>();
            bandages.bandagesStack += bandagesAmount;
        }
    }
}
