using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public Player player;
    public Enemy currentEnemy;

    private void OnEnable()
    {
        TurnManager.OnTurnChanged += HandleTurnChanged;
        Enemy.OnEnemyDie += HandleEnemyDeath;

    }

    private void OnDisable()
    {
        TurnManager.OnTurnChanged -= HandleTurnChanged;
        Enemy.OnEnemyDie -= HandleEnemyDeath;

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
        if (currentEnemy == deadEnemy)
        {
            currentEnemy = EnemyManager.Instance.GetFirstEnemy();
        }
    }
}
