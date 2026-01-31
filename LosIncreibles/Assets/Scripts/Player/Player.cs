using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Turnable
{
    public static event Action OnPlayerAttack;
    public static event Action<Turnable> OnTurnEnd;

    private bool isMyTurn = true;

    public float maxHP = 100f;

    private float currentHP;


    private void Update()
    {
        if(isMyTurn)
        {
            if (InputSystem.actions["Jump"].triggered)
            {
                EndTurn();
            }
        }
    }
    public void EndTurn()
    {
        isMyTurn = false;
        OnTurnEnd?.Invoke(this);
    }

    public void StartTurn()
    {
        isMyTurn = true;
    }

    public void Attack(float damage)
    {
        CombatManager.Instance.currentEnemy.TakeDamage(damage);
        OnPlayerAttack?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
