using UnityEngine;

[CreateAssetMenu(fileName = "ComedyMask", menuName = "Masks/ComedyMask")]

public class ComedyMask : Mask
{
    public override void ApplyMaskEffect()
    {
        Player player = CombatManager.Instance.player;

        if(player.GetComponent<Comedy>() == null)
        {
            player.gameObject.AddComponent<Comedy>();
        }
    }

    public override void RemoveMaskEffect()
    {
        Player player = CombatManager.Instance.player;
        Comedy comedy = player.GetComponent<Comedy>();
        if (comedy != null)
        {
            Destroy(comedy);
        }
    }
}
