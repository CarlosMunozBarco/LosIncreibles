using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour, Turnable
{
    public static event Action<Turnable> OnTurnEnd;
    public static event Action<Enemy> OnEnemyDie;

    public float maxHP = 100f;

    private float currentHP;
    private bool isMyTurn = false;
    private bool hasActed = false;

    private void Start()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        if (isMyTurn && !hasActed)
        {
            Debug.Log("Considerate atacado");
            hasActed = true;
            StartCoroutine(FinishTurn());
        }
    }

    private IEnumerator FinishTurn()
    {
        yield return new WaitForSeconds(3f); // Simulate thinking time
        EndTurn();
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
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnEnemyDie.Invoke(this);
        Destroy(gameObject);
    }
}
