using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MysteryMask", menuName = "Scriptable Objects/MysteryMask")]
public class MysteryMask : Mask
{
    public List<MysteryMaskType> mysteryMaskTypes;
    public int numberOfIntents = 1;

    [Header("Poison Mask Settings")]
    public int poisonStacksPerHit = 2;
    public float damagePerStack = 1f;

    public override void ApplyMaskEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveMaskEffect()
    {
        throw new System.NotImplementedException();
    }

    private void ApplyPoison()
    {
        Enemy currentEnemy = CombatManager.Instance.currentEnemy;
        if (currentEnemy != null)
        {
            if (currentEnemy.GetComponent<Poison>() != null)
            {
                currentEnemy.GetComponent<Poison>().posionStacks =
                    currentEnemy.GetComponent<Poison>().posionStacks + poisonStacksPerHit;
            }
            else
            {
                currentEnemy.AddComponent<Poison>();
                currentEnemy.GetComponent<Poison>().damagePerTurn = damagePerStack;
                currentEnemy.GetComponent<Poison>().posionStacks = poisonStacksPerHit;
            }
        }
    }


}

public enum MysteryMaskType
{
    Posion,
    Shield,
    Dodge,
    Laugh,
    Thorns,
    Bandage
}
