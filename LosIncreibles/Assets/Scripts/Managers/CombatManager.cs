using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public Player player;
    private Enemy currentEnemy;

    private void OnEnable()
    {
        TurnManager.OnTurnChanged += HandleTurnChanged;
        Enemy.OnEnemyDie += HandleEnemyDeath;
        EnemyManager.OnWaveSpawned += HandleWaveSpawned;

    }

    private void OnDisable()
    {
        TurnManager.OnTurnChanged -= HandleTurnChanged;
        Enemy.OnEnemyDie -= HandleEnemyDeath;
        EnemyManager.OnWaveSpawned -= HandleWaveSpawned;

    }

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

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        currentEnemy = EnemyManager.Instance.GetFirstEnemy();
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void HandleTurnChanged(Turn turn)
    {
        if(turn == Turn.Enemy)
            currentEnemy = EnemyManager.Instance.GetFirstEnemy();
    }

    private void HandleEnemyDeath(Enemy deadEnemy)
    {
        if (currentEnemy == null)
        {
            currentEnemy = EnemyManager.Instance.GetFirstEnemy();
        }
    }

    private void HandleWaveSpawned()
    {
        currentEnemy = EnemyManager.Instance.GetFirstEnemy();
    }

    public Enemy GetCurrentEnemy()
    {
        if(currentEnemy == null)
        {
            currentEnemy = EnemyManager.Instance.GetFirstEnemy();
        }
        return currentEnemy;
    }
}
