using UnityEngine;

public class Fear : MonoBehaviour
{
    public float shieldPerTurn = 5f;
    public float damagePerTurn = 1f;

    private void OnEnable()
    {
        TurnManager.OnTurnChanged += HandleTurnChanged;
    }

    private void OnDisable()
    {
        TurnManager.OnTurnChanged -= HandleTurnChanged;
    }


    public void HandleTurnChanged(Turn turn)
    {
        if (turn == Turn.Player)
        {
            CombatManager.Instance.player.shield += shieldPerTurn;
            CombatManager.Instance.player.TakeTrueDamage(damagePerTurn);
            damagePerTurn *= 2f;
        }
    }

}
