using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mystery : MonoBehaviour
{
    public int numberOfIntents = 1;

    public List<MysteryMaskType> mysteryMaskTypes;

    private List<MysteryMaskType> usedMaskTypes = new List<MysteryMaskType>();

    [Header("Poison Mask Settings")]
    public int poisonStacksPerHit = 2;
    public float damagePerStack = 1f;

    [Header("Shield Mask Settings")]
    public int shieldAmount = 10;

    private void OnEnable()
    {
        TurnManager.OnTurnChanged += HandleTurnChanged;
    }

    private void OnDisable()
    {
        TurnManager.OnTurnChanged -= HandleTurnChanged;
    }

    private void HandleTurnChanged(Turn turn)
    {
        if (turn == Turn.Player)
        {
            DeactivatePreviousEffects();
            ActivateRandomMaskEffect();
        }
    }

    private void ApplyPoison()
    {
        Enemy currentEnemy = CombatManager.Instance.GetCurrentEnemy();
        if (currentEnemy != null)
        {
            if (currentEnemy.GetComponent<Poison>() != null)
            {
                currentEnemy.GetComponent<Poison>().poisonStacks =
                    currentEnemy.GetComponent<Poison>().poisonStacks + poisonStacksPerHit;
            }
            else
            {
                currentEnemy.AddComponent<Poison>();
                currentEnemy.GetComponent<Poison>().damagePerTurn = damagePerStack;
                currentEnemy.GetComponent<Poison>().poisonStacks = poisonStacksPerHit;
            }
        }
    }

    public void ActivateRandomMaskEffect()
    {
        for (int i = 0; i < numberOfIntents; i++)
        {
            int randomIndex = Random.Range(0, mysteryMaskTypes.Count);
            MysteryMaskType selectedMaskType = mysteryMaskTypes[randomIndex];
            switch (selectedMaskType)
            {
                case MysteryMaskType.Posion:
                    ApplyPoison();
                    break;
                case MysteryMaskType.Shield:
                    ApplyShield();
                    break;
                case MysteryMaskType.Dodge:
                    ApplyDodge();
                    break;
                case MysteryMaskType.Laugh:
                    ApplyLaugh();
                    break;
                case MysteryMaskType.Thorns:
                    ApplyThrons();
                    break;
                case MysteryMaskType.Bandage:
                    ApplyBandages();
                    break;
                default:
                    Debug.LogWarning("Unknown Mystery Mask Type");
                    break;
            }
        }
    }

    public void DeactivatePreviousEffects()
    {
        if(usedMaskTypes.Contains(MysteryMaskType.Dodge))
        {
            CombatManager.Instance.player.UpdateDodge(-0.2f);
        }
    }

    public void ApplyShield()
    {
        Debug.Log("Applying Shield: " + shieldAmount);
        Player player = CombatManager.Instance.player;
        if (player != null)
        {
            player.UpdateShield(shieldAmount);
        }
    }

    public void ApplyDodge()
    {
        Debug.Log("Applying Dodge");
        Player player = CombatManager.Instance.player;
        if (player != null)
        {
            player.UpdateDodge(0.2f);
        }
        usedMaskTypes.Add(MysteryMaskType.Dodge);
    }

    public void ApplyLaugh()
    {
        Debug.Log("Applying Laugh");
        Enemy currentEnemy = CombatManager.Instance.GetCurrentEnemy();
        if (currentEnemy != null)
        {
            if (currentEnemy.GetComponent<Laugh>() == null)
            {
                currentEnemy.gameObject.AddComponent<Laugh>();
            }
        }
    }

    public void ApplyThrons()
    {
        Debug.Log("Applying Thorns");
        Player player = CombatManager.Instance.player;
        if (player.GetComponent<Thorns>() == null)
        {
            Thorns thorn = player.gameObject.AddComponent<Thorns>();
            thorn.AddThornsStacks(1);
        }
        else
        {
            Thorns thorn = player.gameObject.GetComponent<Thorns>();
            thorn.AddThornsStacks(1);
        }
    }

    public void ApplyBandages()
    {
        Debug.Log("Applying Bandages");
        Player player = CombatManager.Instance.player;
        if (player.GetComponent<Bandages>() == null)
        {
            Bandages bandage = player.gameObject.AddComponent<Bandages>();
            bandage.AddBandagesStacks(1);
        }
        else
        {
            Bandages bandage = player.gameObject.GetComponent<Bandages>();
            bandage.AddBandagesStacks(1);
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