using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Drama : MonoBehaviour
{
    public int poisonStacksPerHit = 2;
    public float damagePerStack = 1f;

    private void OnEnable()
    {
        Player.OnPlayerAttack += HandlePlayerAttack;
    }

    private void OnDisable()
    {
        Player.OnPlayerAttack -= HandlePlayerAttack;
    }

    public void HandlePlayerAttack()
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
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }
}
