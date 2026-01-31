using UnityEngine;

public class Laugh : MonoBehaviour
{
    private Enemy currentEnemy;

    private void OnEnable()
    {
        TurnManager.OnTurnChanged += TriggerLaugh;
    }

    private void OnDisable()
    {
        TurnManager.OnTurnChanged -= TriggerLaugh;
    }

    private void Awake()
    {
        currentEnemy = GetComponent<Enemy>();
    }

    public void TriggerLaugh(Turn turn)
    {
        if (turn == Turn.Enemy && currentEnemy != null)
        {
            currentEnemy.canPlayThisTurn = false;
            Destroy(this);
        }
    }
}
