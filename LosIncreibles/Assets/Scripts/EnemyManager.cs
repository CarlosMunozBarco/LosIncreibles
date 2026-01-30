using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public List<Enemy> currentEnemies;


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
        Enemy.OnEnemyDie += HandleEnemyDeath;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDie -= HandleEnemyDeath;
    }

    public Enemy GetFirstEnemy()
    {
        if (currentEnemies.Count > 0)
        {
            return currentEnemies[0];
        }
        return null;
    }

    public List<Enemy> GetAllEnemies()
    {
        return currentEnemies;
    }

    private void HandleEnemyDeath(Enemy deadEnemy)
    {
        currentEnemies.Remove(deadEnemy);
    }
}
