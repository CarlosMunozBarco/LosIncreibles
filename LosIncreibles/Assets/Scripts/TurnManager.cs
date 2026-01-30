using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Turn currentTurn;
    public Player Player;
    public List<Enemy> Enemies;

    private int currentEnemyIndex = 0;

    private void OnEnable()
    {
        Player.OnTurnEnd += OnTurnFinished;
        Enemy.OnTurnEnd += OnTurnFinished;
    }

    private void OnDisable()
    {
        Player.OnTurnEnd -= OnTurnFinished;
        Enemy.OnTurnEnd -= OnTurnFinished;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTurn = Turn.Player;
        StartTurn();
    }

    private void StartTurn()
    {
        if(currentTurn == Turn.Player)
        {
            Player.StartTurn();
        }
        else if (currentTurn == Turn.Enemy)
        {
            Enemies[currentEnemyIndex].StartTurn();
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
            if (currentEnemyIndex >= Enemies.Count)
            {
                SwapTurn();
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
}

public enum Turn
{
    Player,
    Enemy
}
