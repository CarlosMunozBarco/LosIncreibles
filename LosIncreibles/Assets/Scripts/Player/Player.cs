using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Turnable
{
    public static event Action OnPlayerAttack;
    public static event Action<Turnable> OnTurnEnd;

    private bool isMyTurn = true;

    public float maxHP = 100f;
    public float shield = 0;
    private float currentHP;

    public float dodgeChance = 0f;

    
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
    private void Start()
    {
        currentHP = maxHP;
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
        if(UnityEngine.Random.value < dodgeChance)
        {
            Debug.Log("Player dodged the attack!");
            return;
        }

        float effectiveDamage = damage - shield;
        shield -= effectiveDamage;
        if(shield < 0) shield = 0;
        if (effectiveDamage < 0) effectiveDamage = 0;


        currentHP -= effectiveDamage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void TakeTrueDamage(float damage)
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
