using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MysteryMask", menuName = "Masks/MysteryMask")]
public class MysteryMask : Mask
{
    public List<MysteryMaskType> mysteryMaskTypes;

    public override void ApplyMaskEffect()
    {
        Player player = CombatManager.Instance.player;
        if(player.GetComponent<Mystery>() == null)
        {
            player.AddComponent<Mystery>().mysteryMaskTypes = mysteryMaskTypes;
        }
    }

    public override void RemoveMaskEffect()
    {
        Player player = CombatManager.Instance.player;
        if (player.GetComponent<Mystery>() != null)
        {
            Destroy(player.GetComponent<Mystery>());
        }
    }
}


