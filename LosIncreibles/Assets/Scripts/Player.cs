using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Turnable
{
    public static event Action<Turnable> OnTurnEnd;

    private bool isMyTurn = true;

    public float maxHP = 100f;

    private float currentHP;
    private Enemy currentEnemy;

    private void OnEnable()
    {
        Enemy.OnEnemyDie += HandleEnemyDeath;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDie -= HandleEnemyDeath;
    }


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
        currentEnemy = EnemyManager.Instance.GetFirstEnemy();
        isMyTurn = true;
    }

    public void Attack(float damage)
    {
        currentEnemy.TakeDamage(damage);
    }

    private void HandleEnemyDeath(Enemy deadEnemy)
    {
        if(currentEnemy == deadEnemy)
        {
            currentEnemy = EnemyManager.Instance.GetFirstEnemy();
        }
    }
}
