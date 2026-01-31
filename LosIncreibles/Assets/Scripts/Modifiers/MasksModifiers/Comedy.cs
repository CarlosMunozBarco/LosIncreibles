using UnityEngine;

public class Comedy : MonoBehaviour
{
    public float laughChance = 0.5f;

    public float damage = 5f;
    public float heal = 5f;

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
        Enemy currentEnemy = CombatManager.Instance.GetCurrentEnemy();
        if (currentEnemy != null)
        {
            float roll = Random.Range(0f, 1f);
            if (roll <= laughChance)
            {
                if (currentEnemy.GetComponent<Laugh>() == null)
                {
                    currentEnemy.gameObject.AddComponent<Laugh>();
                }
                else
                {
                    currentEnemy.TakeDamage(damage);
                    CombatManager.Instance.player.Heal(heal);
                }
            }
        }
        else
        {
            Debug.Log("CombatManager bugeado, no hay enemigo");
        }
    }

}
