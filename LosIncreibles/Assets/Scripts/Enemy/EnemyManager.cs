using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static event Action OnWaveSpawned;
    public static event Action OnBossSpawned;
    public static EnemyManager Instance;

    public List<Transform> enemySpawnPoints;
    public List<Wave> waves;

    public List<Enemy> currentEnemies;

    private int currentWaveIndex = 0;

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

        SpawnWave();

    }


    private void OnEnable()
    {
        Enemy.OnEnemyDie += HandleEnemyDeath;
        TurnManager.OnTurnChanged += HandleTurnChange;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDie -= HandleEnemyDeath;
        TurnManager.OnTurnChanged -= HandleTurnChange;
    }

    public Enemy GetFirstEnemy()
    {
        if (currentEnemies.Count > 0)
        {
            return currentEnemies[0];
        }
        Debug.Log("No enemies available to return.");
        return null;
    }

    public List<Enemy> GetAllEnemies()
    {
        return currentEnemies;
    }

    private void HandleEnemyDeath(Enemy deadEnemy)
    {
        currentEnemies.Remove(deadEnemy);
        if(currentEnemies.Count <= 0)
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        if(currentWaveIndex >= waves.Count)
        {
            Debug.Log("All waves have been spawned.");
            return;
        }
        Wave wave = waves[currentWaveIndex];
        if(wave != null)
        {
            Debug.Log("Spawning Wave: " + (currentWaveIndex + 1));
        }
        else
        {
            Debug.Log("No more waves to spawn.");
            return;
        }

        for (int i = 0; i < wave.enemies.Count; i++)
        {
            Enemy enemy = Instantiate(wave.enemies[i], enemySpawnPoints[i]);
            enemy.transform.localPosition = Vector3.zero;
            currentEnemies.Add(enemy);
        }

        currentWaveIndex++;

        if(currentWaveIndex == waves.Count)
        {
            OnBossSpawned?.Invoke();
            SoundsManager.Instance.PlayMusic(MusicType.Boss);
            Debug.Log("Boss Wave Spawned!");
        }
        else
            OnWaveSpawned?.Invoke();

        Debug.Log("Current Enemies Count: " + currentEnemies.Count);
    }

    private void HandleTurnChange(Turn turn)
    {
        if(turn == Turn.Enemy)
        {
            if(currentEnemies.Count <= 0)
            {
                SpawnWave();
            }
        }
    }

    public void StartTurn(int i)
    {
        if(i < currentEnemies.Count)
        {
            currentEnemies[i].StartTurn();
        }
    }
}
