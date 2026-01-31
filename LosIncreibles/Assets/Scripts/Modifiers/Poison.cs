using UnityEngine;

public class Poison : MonoBehaviour
{
    public Enemy targetEnemy;
    public float damagePerTurn;

    public int posionStacks = 1;

    private void Awake()
    {
        targetEnemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        TurnManager.OnTurnChanged += HandleTurnChanged;
    }

    private void OnDisable()
    {
        TurnManager.OnTurnChanged -= HandleTurnChanged;
    }

    private void HandleTurnChanged(Turn turn)
    {
        if(turn == Turn.Enemy)
        {
            targetEnemy.TakeDamage(damagePerTurn * posionStacks);
            posionStacks--;

            if(posionStacks <= 0)
            {
                Destroy(this);
            }
        }
    }
}
