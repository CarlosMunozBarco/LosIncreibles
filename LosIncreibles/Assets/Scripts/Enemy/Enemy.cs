using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour, Turnable
{
    public static event Action<Turnable> OnTurnEnd;
    public static event Action<Enemy> OnEnemyDie;
     public static event Action<Enemy> OnEnemyAttack;

    public float maxHP = 100f;
    public float shield = 0;
    public int damage = 15;
    public float dodgeChance = 0f;
    public bool isBoss = false;

    private float currentHP;
    private bool isMyTurn = false;
    private bool hasActed = false;

    public bool canPlayThisTurn = true;
    private bool hasDied = false;
    private void Start()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        if (isMyTurn && !hasActed)
        {
            StartCoroutine(FinishTurn());

            if(canPlayThisTurn)
                AttackPlayer();

            hasActed = true;
        }
    }

    private IEnumerator FinishTurn()
    {
        yield return new WaitForSeconds(3f); // Simulate thinking time
        canPlayThisTurn = true;
        EndTurn();
    }

    public void AttackPlayer()
    {
        Debug.Log("Attacking Player for " + damage + " damage.");
        CombatManager.Instance.player.TakeDamage(damage);
        OnEnemyAttack?.Invoke(this);
    }


    public void EndTurn()
    {
        isMyTurn = false;
        OnTurnEnd?.Invoke(this);

    }

    public void StartTurn()
    {
        isMyTurn = true;
        hasActed = false;
    }

    public void TakeDamage(float damage)
    {
        if (UnityEngine.Random.value < dodgeChance)
        {
            return;
        }

        float effectiveDamage = damage - shield;
        if (effectiveDamage < 0) effectiveDamage = 0;

        currentHP -= effectiveDamage;
        if (currentHP <= 0 && !hasDied)
        {
            Die();
        }
    }

    private void Die()
    {
        hasDied = true;
        OnEnemyDie.Invoke(this);
        OnTurnEnd?.Invoke(this);
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

    public void AddShield(float amount)
    {
        shield += amount;
    }
}
