using UnityEngine;

public class Thorns : MonoBehaviour
{
    public Player player;
    public Enemy targetEnemy;
    public int thornsStack;

    private int turnsOfDurations = 3;

    void OnEnable()
    {
        Enemy.OnEnemyAttack += HurtEnemy;
        TurnManager.OnTurnChanged += HandleTurnChanged;
    }
    void Awake()
    {
        player = GetComponent<Player>();
    }
    void OnDisable()
    {
        Enemy.OnEnemyAttack -= HurtEnemy;
        TurnManager.OnTurnChanged -= HandleTurnChanged;
    }

    public void HurtEnemy(Enemy enemy)
    {
        enemy.TakeDamage(thornsStack);
    }
    public void AddThornsStacks(int numberStack)
    {
        thornsStack += numberStack;
        turnsOfDurations = 3;
    }
    private void HandleTurnChanged(Turn turn)
    {
        if(turn == Turn.Player)
        {
            turnsOfDurations--;
            if (turnsOfDurations == 0)
            {
                thornsStack = 0;
            }
        }
    }


}
