using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public static event Action<Turn> OnTurnChanged;
    public Turn currentTurn;
    public Player player;

    private int currentEnemyIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Player.OnTurnEnd += OnTurnFinished;
        Enemy.OnTurnEnd += OnTurnFinished;
        Enemy.OnEnemyDie += HandleEnemyDie;
    }

    private void OnDisable()
    {
        Player.OnTurnEnd -= OnTurnFinished;
        Enemy.OnTurnEnd -= OnTurnFinished;
        Enemy.OnEnemyDie -= HandleEnemyDie;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTurn = Turn.Enemy;
        StartTurn();
    }

    private void StartTurn()
    {
        OnTurnChanged?.Invoke(currentTurn == Turn.Player ? Turn.Player : Turn.Enemy);
        if (currentTurn == Turn.Player)
        {
            player.StartTurn();
        }
        else if (currentTurn == Turn.Enemy)
        {
            EnemyManager.Instance.StartTurn(currentEnemyIndex);
        }
    }

    public void OnTurnFinished(Turnable turnable)
    {
        if(currentTurn == Turn.Player)
        {
            SwapTurn();
        }
        else
        {
            currentEnemyIndex++;
            if (currentEnemyIndex >= EnemyManager.Instance.GetAllEnemies().Count)
            {
                SwapTurn();
            }
            else
            {
                EnemyManager.Instance.StartTurn(currentEnemyIndex);
            }
        }
    }

    public void SwapTurn()
    {
        if(currentTurn == Turn.Player)
        {
            currentTurn = Turn.Enemy;
            currentEnemyIndex = 0;
        }
        else if (currentTurn == Turn.Enemy)
        {
            currentTurn = Turn.Player;
            currentEnemyIndex = 0;
        }

        StartTurn();
    }

    private void HandleEnemyDie(Enemy deadEnemy)
    {
        var allEnemies = EnemyManager.Instance.GetAllEnemies();
        if (allEnemies.Count == 0)
        {
            SwapTurn();
        }
        else if (currentTurn == Turn.Enemy)
        {
            if (currentEnemyIndex >= allEnemies.Count)
            {
                SwapTurn();
            }
        }
    }
}

public enum Turn
{
    Player,
    Enemy
}
